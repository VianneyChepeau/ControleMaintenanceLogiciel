using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class CommandManager
    {
        public ShowCommand show { get; }
        public HelpCommand help { get; }
        public AddCommand add { get; }
        public ErrorCommand error { get; }
        public StateTaskCommand state { get; set; }
        
        public CommandManager(IConsole console)
        {
            show = new ShowCommand(console);
            help = new HelpCommand(console);
            add = new AddCommand(console);
            error = new ErrorCommand(console); 
        }
    }
}
