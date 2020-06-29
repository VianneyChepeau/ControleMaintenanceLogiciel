using System;
using System.IO;
using System.Threading;
using NUnit.Framework;

namespace Tasks
{
	[TestFixture]
	public sealed class ApplicationTest
	{  
		private FakeConsole console;
		private Thread applicationThread;

		[SetUp]
		public void StartTheApplication()
		{
			this.console = new FakeConsole(); 
			this.applicationThread = new Thread(() => new TaskList(console).Run());
			applicationThread.Start();
		}

		[TearDown]
		public void KillTheApplication()
		{
			if (applicationThread == null || !applicationThread.IsAlive)
				return;

			applicationThread.Abort();
			throw new Exception("The application is still running.");
		}

		[Test, Timeout(1000)]
		public void ItWorks()
		{
			console.Execute("show");

			console.Execute("add project secrets");
			console.Execute("add task secrets Eat more donuts.");
			console.Execute("add task secrets Destroy all humans.");

			console.Execute("show");
			console.ReadLines(
				"secrets",
				"    [ ] 1: Eat more donuts.",
				"    [ ] 2: Destroy all humans.",
				""
			);

			console.Execute("add project training");
			console.Execute("add task training Four Elements of Simple Design");
			console.Execute("add task training SOLID");
			console.Execute("add task training Coupling and Cohesion");
			console.Execute("add task training Primitive Obsession");
			console.Execute("add task training Outside-In TDD");
			console.Execute("add task training Interaction-Driven Design");

			console.Execute("check 1");
			console.Execute("check 3");
			console.Execute("check 5");
			console.Execute("check 6");

			console.Execute("show");
			console.ReadLines(
				"secrets",
				"    [x] 1: Eat more donuts.",
				"    [ ] 2: Destroy all humans.",
				"",
				"training",
				"    [x] 3: Four Elements of Simple Design",
				"    [ ] 4: SOLID",
				"    [x] 5: Coupling and Cohesion",
				"    [x] 6: Primitive Obsession",
				"    [ ] 7: Outside-In TDD",
				"    [ ] 8: Interaction-Driven Design",
				""
			);

			console.Execute("quit");
		}

		[Test]
		public void AddProject()
        { 
			console.Execute("add project secrets"); 
			console.Execute("show");
			console.ReadLines(
				"secrets", 
				""
			);
			console.Execute("quit");
		}
		
		[Test]
		public void AddProjectWithNameEmpty()
        { 
			console.Execute("add project");  
			console.ReadLines(
				"Veuillez indiquer le nom du projet"
			);
			console.Execute("quit");
		}

		[Test]
		public void AddProjectTask()
		{
			console.Execute("add project secrets");
			console.Execute("add task secrets Eat more donuts."); 

			console.Execute("show");
			console.ReadLines(
				"secrets",
				"    [ ] 1: Eat more donuts.", 
				""
			);
			console.Execute("quit");
		}
		
		[Test]
		public void AddProjectTaskWithTaskNameEmpty()
		{
			console.Execute("add project secrets");
			console.Execute("add task");

			console.ReadLines(
				"Veuillez indiquer le nom du projet et la description de la tâche"
			);
			console.Execute("quit");
		}
	}
}
