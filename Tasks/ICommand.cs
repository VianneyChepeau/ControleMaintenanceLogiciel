using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public interface ICommand <T>
    {
        string GetName();

        void Execute(T param); 
    }
}
