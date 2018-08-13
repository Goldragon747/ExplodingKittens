using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExplodingKittens.Tests.Writers
{
	[TestClass]
	public class ConsoleWriterShould
	{
		[TestMethod]
		public void StoreMessageWhenWritten()
		{
			// Arrange
			ExplodingKittens.Writers.ConsoleWriter writer = new ExplodingKittens.Writers.ConsoleWriter();

			// Act
			writer.Write("test");

			// Assert
			NUnit.Framework.Assert.AreEqual(writer.Message, "test");
		}
	}
}
