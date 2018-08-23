
using ExplodingKittensLib.Models.Players;

namespace ExplodingKittensLib.Models.Cards
{
	public class Nope : Card
	{
		public Nope(Game game, int id, string tagline)
			: base(game, id, "Nope", tagline, "Stop the action of another player. You can play this at any time.")
		{
		}

        public Nope(Game game, int id)
    : base(game, id, "Nope", "Stop the action of another player. You can play this at any time.")
        {
        }

        public override ActionResponse Play()
		{
			ActionResponse res = new ActionResponse();
			res.AddMessage("Nope!\n");
			return res;
		}

		public override ActionResponse Play(Player player)
		{
			throw new System.NotImplementedException();
		}
	}
}
