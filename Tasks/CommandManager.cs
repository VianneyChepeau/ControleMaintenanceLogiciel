using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class CommandManager
    {
        public ShowCommand show { get; }
        
        public CommandManager()
        {
            show = new ShowCommand();
        }
    }
}
