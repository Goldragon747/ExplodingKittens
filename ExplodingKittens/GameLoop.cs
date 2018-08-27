using ExplodingKittensLib.Models.Players;
using ExplodingKittensLib.Models.Writers;
using ExplodingKittensLib.Models;
using System;

namespace ExplodingKittens
{
	public class GameLoop
	{
		public ConsoleGame Game { get; set; }
		public Player CurrentPlayer { get; set; }
		public ActionResponse CurrentActionResponse { get; set; }

		/// <summary>
		/// Turn has finished when the active player has changed, and the current player 
		/// isn't being asked for a favour or stolen from
		/// </summary>
		/// <returns>Whether the current player's turn has finished or not</returns>
		public bool TurnHasFinished
		{
			get
			{
				return (Game.HasFinished ||
					(CurrentPlayer.Id != Game.ActivePlayer.Id &&
					!CurrentPlayer.IsAskedForFavor &&
					!CurrentPlayer.IsBeingStolenFrom));
			}
		}

		public GameLoop()
		{
		}

		public void Setup()
		{
			while (Game == null)
			{
				Console.WriteLine("Welcome to Exploding Kittens.\n");
				Console.WriteLine("              ^   ^    ");
				Console.WriteLine("             / \\ / \\ ");
				Console.WriteLine("    ??      ( 0   0 )  ");
				Console.WriteLine("    ??_____ |   V   |  ");
				Console.WriteLine("    (          ===  )  ");
				Console.WriteLine("    (               )  ");
				Console.WriteLine("    (_______________)  ");
				Console.WriteLine("      ()         ()    ");
				Console.WriteLine("\nPlease enter the number of players (between 2 and 5):\n");

				int numberOfPlayers = Utilities.GetIntFromString(Console.ReadLine(), 0);
				
				Console.WriteLine();

				try
				{
                    Game = new ConsoleGame(numberOfPlayers, new ConsoleWriter());//, true);

					Start();
				}
				catch (ArgumentException e)
				{
					Console.WriteLine(string.Format("{0}\n", e.Message));
				}
			}
		}

		private void Start()
		{
			while (!Game.HasFinished)
			{
				CurrentPlayer = Game.ActivePlayer;

				while (!TurnHasFinished)
				{
					CheckIfFavorHasBeenPlayed();
					Game.GetCommand(Console.ReadLine(), CurrentPlayer).Execute().PrintAll();
				}
			}

			Game.EndGame();
		}

		/// <summary>
		/// Check to see if a favour card has been played
		/// </summary>
		private void CheckIfFavorHasBeenPlayed()
		{
			if (Game.PlayerBeingAskedForFavor is NullPlayer)
				Game.PrintTurnMessage(CurrentPlayer.Id);
			else
			{
				CurrentPlayer = Game.PlayerBeingAskedForFavor;
				Game.PrintFavorMessage(CurrentPlayer.Id);
			}
		}
	}
}
