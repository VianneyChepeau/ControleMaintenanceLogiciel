using NUnit.Framework; 

namespace Tasks.Tests
{
    [TestFixture]
    public class CommandTest
    {
        //private TaskList _taskList;
        private IConsole console;

        [SetUp]
        public void Setup()
        {
            console = new RealConsole();
            //_taskList = new TaskList(new RealConsole());
        }

        [Test]
        public void GetNameCommandTest()
        {
            ShowCommand showCommand = new ShowCommand(console);
            Assert.AreEqual("show", showCommand.GetName());
        }
    }
}
