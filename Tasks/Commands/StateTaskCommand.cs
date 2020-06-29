using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasks
{
    public class StateTaskCommand : ICommand
    {
        private readonly IConsole console;
        private string idString;
        private bool done;

        public StateTaskCommand(IConsole console, string idString, bool done)
        {
            this.console = console;
            this.idString = idString;
            this.done = done;
        }

        public string GetName()
        {
            return done ? "check" : "uncheck";
        }

        public IDictionary<string, IList<Task>> Execute(IDictionary<string, IList<Task>> tasks)
        {
            int id = int.Parse(idString);
            var identifiedTask = tasks.Select(project => project.Value.FirstOrDefault(task => task.Id == id))
                                      .Where(task => task != null)
                                      .FirstOrDefault();
            if (identifiedTask == null)
                console.WriteLine("Could not find a task with an ID of {0}.", id);
            else
                identifiedTask.Done = done;

            return tasks;
        }
    }
}
