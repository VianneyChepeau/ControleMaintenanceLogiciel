using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class AddCommand : ICommand<string>
    {
        public string GetName()
        {
            return "add";
        }

        public void Execute(string commandLine)
        {
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


        private void AddProject(string name)
        {
            tasks[name] = new List<Task>();
        }

    }
}
