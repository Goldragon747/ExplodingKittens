using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ExplodingKittens.Tests.Cards
{
	[TestClass]
	public class DefuseShould
	{
		[TestMethod]
		public void Have_non_empty_explanation()
		{
			// Arrange & Act
			ExplodingKittens.Cards.Defuse defuse = new ExplodingKittens.Cards.Defuse(null, 1, "Test defuse card");

			// Assert
			NUnit.Framework.Assert.IsNotEmpty(defuse.Explanation);
		}

		[TestMethod]
		public void Write_a_defuse_message_when_played()
		{
			// Arrange
			Game game = new Game(2, new ExplodingKittens.Writers.MemoryWriter());
			ExplodingKittens.Cards.Defuse defuse = new ExplodingKittens.Cards.Defuse(game, 1, "Test defuse card");

			// Act
			defuse.Play();

			// Assert
			NUnit.Framework.Assert.AreEqual(game.Writer.Message, "Exploding kitten defused.\n\n");
		}

		[TestMethod]
		public void Not_implement_play_method_called_with_another_player()
		{
			// Arrange
			Game game = new Game(2);
			ExplodingKittens.Cards.Defuse defuse = new ExplodingKittens.Cards.Defuse(game, 1, "Test defuse card");

			// Act, assert
			NUnit.Framework.Assert.That(() => defuse.Play(game.NextPlayer), Throws.Exception.TypeOf<NotImplementedException>());
		}
	}
}