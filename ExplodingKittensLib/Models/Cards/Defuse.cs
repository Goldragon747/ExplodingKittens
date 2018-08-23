
using ExplodingKittensLib.Models.Players;

namespace ExplodingKittensLib.Models.Cards
{
    public class Defuse : Card
    {
        public Defuse(Game game, int id, string tagline)
            : base(game, id, "Defuse", tagline, "Put your last drawn card back into the deck.")
        {
        }

        public Defuse(Game game, int id)
            : base(game, id, "Defuse", "Put your last drawn card back into the deck.")
        {
        }

        public override ActionResponse Play()
        {
            return new ActionResponse(new Message(Enums.Severity.Info, string.Format("Exploding kitten defused {0}.", TagLine.ToLower())));
        }

        public override ActionResponse Play(Player player)
        {
            throw new System.NotImplementedException("You can't play a defuse on another player, only on an exploding kitten.");
        }
    }
}
