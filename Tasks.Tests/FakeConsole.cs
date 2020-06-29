using NUnit.Framework;
using System;
using System.IO;

namespace Tasks
{
	public class FakeConsole : IConsole
	{
		private readonly TextReader inputReader;
		private readonly TextWriter inputWriter;

		private readonly TextReader outputReader;
		private readonly TextWriter outputWriter;

		public FakeConsole() 
		{
			Stream inputStream = new BlockingStream(new ProducerConsumerStream());
			this.inputReader = new StreamReader(inputStream);
			this.inputWriter = new StreamWriter(inputStream) { AutoFlush = true };

			Stream outputStream = new BlockingStream(new ProducerConsumerStream());
			this.outputReader = new StreamReader(outputStream);
			this.outputWriter = new StreamWriter(outputStream) { AutoFlush = true };
		}

		public string ReadLine()
		{
			return inputReader.ReadLine();
		}

		public void Write(string format, params object[] args)
		{
			outputWriter.Write(format, args);
		}

		public void WriteLine(string format, params object[] args)
		{
			outputWriter.WriteLine(format, args);
		}

		public void WriteLine()
		{
			outputWriter.WriteLine();
		}

		public void SendInput(string input)
		{
			inputWriter.Write(input);
		}

		public string RetrieveOutput(int length)
		{
			var buffer = new char[length];
			outputReader.ReadBlock(buffer, 0, length);
			return new string(buffer);
		}

		public void Execute(string command)
		{
			Read("> ");
			Write(command);
		}

		private void Read(string expectedOutput)
		{
			var actualOutput = RetrieveOutput(expectedOutput.Length);
			Assert.AreEqual(expectedOutput, actualOutput);
		}

		public void ReadLines(params string[] expectedOutput)
		{
			foreach (var line in expectedOutput)
			{
				Read(line + Environment.NewLine);
			}
		}

		public void Write(string input)
		{
			SendInput(input + Environment.NewLine);
		}
	}
}
