using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
	public sealed class TaskList
	{ 
		private IDictionary<string, IList<Task>> tasks = new Dictionary<string, IList<Task>>();
		private static IConsole console;
		private CommandManager commandManager;

		public static void Main(string[] args)
		{
			new TaskList(new RealConsole()).Run();
		}

		public TaskList(IConsole myConsole)
		{
            console = myConsole;
			this.commandManager = new CommandManager(console);
		}

		public void Run()
		{
			while (true) {
				console.Write("> "); 
				Execute(console.ReadLine());
			}
		}

		private void Execute(string commandLine)
		{
			var commandRest = commandLine.Split(" ".ToCharArray(), 2);
			var command = commandRest[0];
			switch (command) {
			case "show":
				commandManager.show.Execute(tasks);
				break;
			case "add":
				tasks = commandManager.add.Execute(tasks, commandRest[1]);
				break;
			case "check":
				commandManager.state = new StateTaskCommand(console, commandRest[1], true);
				tasks = commandManager.state.Execute(tasks);
				break;
			case "uncheck":
				commandManager.state = new StateTaskCommand(console, commandRest[1], false);
				tasks = commandManager.state.Execute(tasks);
				break;
			case "help":
				commandManager.help.Execute();
				break;
			case "quit":
				Environment.Exit(0);
				break;
			default:
				commandManager.error.Execute(command);
				break;
			}
		}
	}
}
