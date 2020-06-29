using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasks
{
    public class AddCommand : ICommand
    {
        private IDictionary<string, IList<Task>> tasks;
        private IConsole console;

        public AddCommand(IConsole console)
        {
            this.console = console;
        }

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
                if (subcommandRest.Length < 2)
                {
                    console.WriteLine("Veuillez indiquer le nom du projet");
                    return tasks;
                }
                return AddProject(subcommandRest[1]);
            }
            else if (subcommand == "task")
            {
                if (subcommandRest.Length < 2)
                {
                    console.WriteLine("Veuillez indiquer le nom du projet et la description de la tâche");
                    return tasks;
                }
                var projectTask = subcommandRest[1].Split(" ".ToCharArray(), 2);
                return AddTask(projectTask[0], projectTask[1]);
            }
            else
                return null;
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

        private long NextId()
        {
            long id = 0;
            List<long> idList = new List<long>();
            if(tasks.Count > 0)
            {
                foreach (var value in tasks.Values)
                {
                    idList.Add(value.Max(x => x.Id));
                }
            }

            if(idList.Count > 0)
                id = idList.Max();

            return id++;
        }
    }
}
