using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class CheckCommand : ICommand
    {
        public string GetName()
        {
            return "check";
        }

        public void Execute()
        {

        }
    }
}
