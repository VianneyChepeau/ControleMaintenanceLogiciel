using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class CommandManager
    {
        public ShowCommand show { get; }
        public HelpCommand help { get; }
        
        public CommandManager(IConsole console)
        {
            show = new ShowCommand(console);
            help = new HelpCommand(console);
        }
    }
}
