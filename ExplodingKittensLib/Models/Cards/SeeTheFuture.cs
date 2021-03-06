﻿using ExplodingKittensLib.Models.Players;
using System.Collections.Generic;

namespace ExplodingKittensLib.Models.Cards
{
	public class SeeTheFuture : Card
	{
		public SeeTheFuture(Game game, int id, string tagline)
			: base(game, id, "See The Future", tagline, "Privately view the top three cards of the deck.")
		{
		}

        public SeeTheFuture(Game game, int id)
    : base(game, id, "See The Future", "Privately view the top three cards of the deck.")
        {
        }

        /// <summary>
        /// Reveals the first 3 cards to the player
        /// Puts the first 3 cards back onto the deck
        /// </summary>
        /// <returns></returns>
		public override ActionResponse Play()
		{
			ActionResponse res = new ActionResponse();
			Stack<Card> drawPile = Game.Deck.DrawPile;

			Card first = drawPile.Pop();
			Card second = drawPile.Pop();
			Card third = drawPile.Pop();

			res.AddMessage(first.ToString());
			res.AddMessage(second.ToString());
			res.AddMessage(third.ToString());

			drawPile.Push(third);
			drawPile.Push(second);
			drawPile.Push(first);

			return res;
		}
        /// <summary>
        /// Prevents the wrong ActionReponse from being done
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
		public override ActionResponse Play(Player player)
		{
			throw new System.NotImplementedException();
		}
	}
}
