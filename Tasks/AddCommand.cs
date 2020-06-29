using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasks
{
    public class AddCommand : ICommand<string>
    {
        private IDictionary<string, IList<Task>> tasks;

        public string GetName()
        {
            return "add";
        }

        public IDictionary<string, IList<Task>> Execute(IDictionary<string, IList<Task>> tasks, string commandLine)
        {
            this.tasks = tasks;

            var subcommandRest = commandLine.Split(" ".ToCharArray(), 2);
            var subcommand = subcommandRest[0];
            if (subcommand == "project")
            {
                AddProject(subcommandRest[1]);
            }
            else if (subcommand == "task")
            {
                var projectTask = subcommandRest[1].Split(" ".ToCharArray(), 2);
                AddTask(projectTask[0], projectTask[1]);
            }
        }


        private IDictionary<string, IList<Task>> AddProject(string name)
        {
            tasks[name] = new List<Task>();
            return tasks;
        }

        private IDictionary<string, IList<Task>> AddTask(string project, string description)
        {
            if (!tasks.TryGetValue(project, out IList<Task> projectTasks))
            {
                Console.WriteLine("Could not find a project with the name \"{0}\".", project);
                return null;
            }
            projectTasks.Add(new Task { Id = NextId(), Description = description, Done = false });

            return tasks;
        }

        private long NextId(IList<Task> projectTasks)
        {
            var lastId = projectTasks.Max(x => x.Id);
            return ++lastId; 
        }
    }
}
