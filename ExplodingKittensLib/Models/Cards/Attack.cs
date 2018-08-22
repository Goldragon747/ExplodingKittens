
using ExplodingKittensLib.Models.Players;

namespace ExplodingKittensLib.Models.Cards
{
	public class Attack : Card
	{
		public Attack(Game game, int id, string tagline)
			: base(game, id, "Attack", tagline, "End your turn without drawing a card. Force the next player to take two turns.")
		{
		}

        /// <summary>
        /// informs the users who is getting attacked
        /// changes the active players under attack to false
        /// changes the netplayer's underattack to true
        /// </summary>
        /// <returns></returns>
		public override ActionResponse Play()
		{
			ActionResponse res = new ActionResponse();
			res.AddMessage(string.Format("Player {0} is under attack!", Game.NextPlayer.Id));

			Game.ActivePlayer.IsUnderAttack = false;
			Game.NextPlayer.IsUnderAttack = true;
			Game.EndTurn();

			return res;
		}
        /// <summary>
        /// Prevents the wrong ActionReponse from being done
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
		public override ActionResponse Play(Player player)
		{
			throw new System.NotImplementedException("You must attack the next player.");
		}
	}
}
