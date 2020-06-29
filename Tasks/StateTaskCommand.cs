using System;
using System.Collections.Generic;
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

        public void Execute()
        {

        }
    }
}
