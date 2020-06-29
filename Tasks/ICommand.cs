using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public interface ICommand
    {
        string GetName();

        void Execute(IList<Task> tasks);
    }
}
