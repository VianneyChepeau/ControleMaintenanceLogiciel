using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class ErrorCommand : ICommand
    {
        private readonly IConsole console;

        public ErrorCommand(IConsole console)
        {
            this.console = console;
        }

        public string GetName()
        {
            return "error";
        }

        public void Execute(string command)
        {
            console.WriteLine("I don't know what the command \"{0}\" is.", command);
        }
    }
}
