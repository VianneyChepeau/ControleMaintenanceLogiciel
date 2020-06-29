using NUnit.Framework; 

namespace Tasks.Tests
{
    [TestFixture]
    public class CommandTest
    {
        //private TaskList _taskList;

        [SetUp]
        public void Setup()
        {
            //_taskList = new TaskList(new RealConsole());
        }

        [Test]
        public void GetNameCommandTest()
        {
            ShowCommand showCommand = new ShowCommand();

            Assert.AreEqual("show", showCommand.GetName());
        }
    }
}
