using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ExplodingKittens.Tests.Cards
{
	[TestClass]
	public class SkipShould
	{
		[TestMethod]
		public void Have_non_empty_explanation()
		{
			// Arrange & Act
			ExplodingKittens.Cards.Skip skip = new ExplodingKittens.Cards.Skip(null, 1, "Test skip card");

			// Assert
			NUnit.Framework.Assert.IsNotEmpty(skip.Explanation);
		}

		[TestMethod]
		public void Assign_turn_to_the_next_player_when_played()
		{
			// Arrange
			Game game = new Game(2);
			ExplodingKittens.Cards.Skip skip = new ExplodingKittens.Cards.Skip(game, 1, "Test skip card");

			// Act
			skip.Play();

			// Assert
			NUnit.Framework.Assert.AreEqual(game.Players.Last.Value, game.ActivePlayer);
		}
	}
}
