using ExplodingKittens.Cards;
using ExplodingKittens.Players;
using System;

namespace ExplodingKittens.Commands
{
	public class PlayCommand : ICommand
	{
		public Game Game { get; set; }
		public Player CurrentPlayer { get; set; }
		public int CurrentTargetPlayerIndex { get; set; }

		public string Description
		{
			get { return string.Format("\"{0}\": Play a card.", CommandType); }
		}

		public Enums.Commands.Command CommandType
		{
			get { return Enums.Commands.Command.Play; }
		}

		public PlayCommand()
		{
		}

		public PlayCommand(Game game, Player player, int index)
		{
			Game = game;
			CurrentPlayer = player;
			CurrentTargetPlayerIndex = index;
		}

		public ActionResponse Execute()
		{
			ActionResponse res = new ActionResponse();

			if (!CurrentPlayer.Hand.HasSelectedCard)
			{
				res.AddError("You must select a card to play");

				return res;
			}

			Game.Writer.WriteLine(string.Format("Player {0} has played the card {1}\n", CurrentPlayer.Id, CurrentPlayer.Hand.SelectedCard.ToString()));

			bool isNoped = false;
			Player firstPlayer = CurrentPlayer;
			Player playerToNope = Game.NextPlayer;

			while (playerToNope != firstPlayer)
			{
				Game.Writer.WriteLine(string.Format("Player {0}, would you like to 'Nope'? (y/n)\n", playerToNope.Id));
				bool hasChosen = false;

				while (!hasChosen)
				{
					string choice = Console.ReadLine();
					Game.Writer.WriteLine();

					if (choice == "y" || choice == "n")
					{
						hasChosen = true;

						if (choice == "y")
						{
							Card nope = playerToNope.Hand.GetNope();
							ActionResponse nopeRes = playerToNope.PlayCard(nope);

							if (nopeRes.IsSuccessful)
							{
								isNoped = !isNoped;
								firstPlayer = playerToNope;
								playerToNope = Game.GetNextPlayer(firstPlayer);
							}
							else
							{
								nopeRes.PrintErrors();
								playerToNope = Game.GetNextPlayer(playerToNope);
							}
						}
						else
						{
							playerToNope = Game.GetNextPlayer(playerToNope);
						}
					}
				}
			}

			if (isNoped)
			{
				res.AddMessage(string.Format("Player {0}'s card ({1}) was successfully 'Noped'.\n", CurrentPlayer.Id, CurrentPlayer.Hand.SelectedCard.Name));
				CurrentPlayer.DiscardCard(CurrentPlayer.Hand.SelectedCard);
			}
			else if (CurrentTargetPlayerIndex <= 0)
				res = CurrentPlayer.PlayCard(CurrentPlayer.Hand.SelectedCard);
			else
				res = CurrentPlayer.PlayCard(CurrentPlayer.Hand.SelectedCard, Game.GetSelectedPlayer(CurrentTargetPlayerIndex));

			return res;
		}
	}
}
