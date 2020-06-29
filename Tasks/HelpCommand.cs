using System;

namespace Tasks
{
    public class HelpCommand : ICommand<string>
    {
        private readonly IConsole console;

        public HelpCommand(IConsole console)
        {
            this.console = console;
        }

        public string GetName()
        {
            return "help";
        }
        public void Execute(string tasks)
        {
            console.WriteLine("Commands:");
            console.WriteLine("  show");
            console.WriteLine("  add project <project name>");
            console.WriteLine("  add task <project name> <task description>");
            console.WriteLine("  check <task ID>");
            console.WriteLine("  uncheck <task ID>");
            console.WriteLine();
        }

        
    }
}
