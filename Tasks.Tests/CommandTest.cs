using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Tests
{
    [TestClass]
    public class CommandTest
    {
        //private TaskList _taskList;

        [SetUp]
        public void Setup()
        {
            //_taskList = new TaskList(new RealConsole());
        }

        [TestMethod]
        public void GetNameCommandTest()
        {
            ShowCommand showCommand = new ShowCommand();

            NUnit.Framework.Assert.AreEqual("show", showCommand.GetName());
        }
    }
}
