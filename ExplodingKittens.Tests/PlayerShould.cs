//using ExplodingKittens.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace ExplodingKittens.Tests
{
    //todo fix tests
	[TestClass]
    public class PlayerShould
	{
		//[TestMethod]
		//public void Have_card_be_selected_when_selected()
		//{
		//	// Arrange
		//	Game game = new Game(2);
		//	Player player = new Player(1, game);
		//	ExplodingKittens.Cards.Card card = new ExplodingKittens.Cards.Attack(game, 1, "Test card");
		//	player.Hand.Cards.Add(1, card);

		//	// Act
		//	player.SelectCard(1);

		//	// Assert
		//	NUnit.Framework.Assert.IsTrue(card.IsSelected);
		//}

		//[TestMethod]
		//public void Have_card_be_deselected_when_deselected()
		//{
		//	// Arrange
		//	Game game = new Game(2);
		//	Player player = new Player(1, game);
		//	ExplodingKittens.Cards.Card card = new ExplodingKittens.Cards.Attack(game, 1, "Test card");
		//	player.Hand.Cards.Add(1, card);

		//	// Act
		//	player.SelectCard(1);
		//	player.DeselectCard(1);

		//	// Assert
		//	NUnit.Framework.Assert.IsFalse(card.IsSelected);
		//}

		//[TestMethod]
		//public void Have_card_added_to_their_hand_when_drawn()
		//{
		//	// Arrange
		//	Game game = new Game(2);
		//	Player player = game.Players.First.Value;
		//	int cardCountBefore = player.Hand.Cards.Count;

		//	// Act
		//	player.DrawCard();

		//	// Assert
		//	NUnit.Framework.Assert.AreEqual(player.Hand.Cards.Count, cardCountBefore += 1);
		//}

		//[TestMethod]
		//public void Have_card_added_to_play_pile_when_played()
		//{
		//	// Arrange
		//	Game game = new Game(2);
		//	Player player = game.Players.First.Value;
		//	int cardCountBefore = game.Deck.PlayPile.Count;

		//	// TODO: FIXME: Need a better way of adding test cards (ie. use test cards rather than actual cards)
		//	ExplodingKittens.Cards.SeeTheFuture testCard = new ExplodingKittens.Cards.SeeTheFuture(game, 0, "Test card");
		//	player.Hand.Cards.Add(testCard.Id, testCard);

		//	// Act
		//	player.PlayCard(testCard);

		//	// Assert
		//	NUnit.Framework.Assert.AreEqual(game.Deck.PlayPile.Count, cardCountBefore += 1);
		//}
	}
}
