using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Tasks
{
    public class ShowCommand : ICommand<IDictionary<string, IList<Task>>>
    {
        private readonly IConsole console;

        public ShowCommand(IConsole console)
        {
            this.console = console;
        }

        public string GetName()
        {
            return "show";
        }

        public void Execute(IDictionary<string, IList<Task>> tasks)
        {
            foreach (var project in tasks)
            {
                console.WriteLine(project.Key);
                foreach (var task in project.Value)
                {
                    console.WriteLine("    [{0}] {1}: {2}", (task.Done ? 'x' : ' '), task.Id, task.Description);
                }
                console.WriteLine();
            }
        }

        
    }
}
