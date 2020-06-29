using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Tasks
{
    public class ShowCommand : ICommand<IList<Task>>
    {
        public string GetName()
        {
            return "show";
        }

        public void Execute(IList<Task> tasks)
        {
            foreach (var project in tasks)
            {
                //Console.WriteLine(project.Key);
                //foreach (var task in project.Value)
                //{
                //    console.WriteLine("    [{0}] {1}: {2}", (task.Done ? 'x' : ' '), task.Id, task.Description);
                //}
                //console.WriteLine();
            }
        }

        
    }
}
