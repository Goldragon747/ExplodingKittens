﻿using ExplodingKittensLib.Models.Cards;
using ExplodingKittensLib.Models.Enums;
using ExplodingKittensLib.Models.Players;
using ExplodingKittensLib.Models.Writers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExplodingKittensLib.Models
{
	public class ConsoleGame : Game
	{
        //public Deck Deck { get; set; }
        public IOutputWriter Writer { get; set; }
        //public LinkedList<Player> Players { get; set; }
        public List<Commands.ICommand> CommandList { get; set; }

        public ConsoleGame(int numberOfPlayers)//, bool isConsoleApp)
            : this(numberOfPlayers, new ConsoleWriter())//, isConsoleApp)
        {
        }

        /// <summary>
        /// Create the only instance of the game class
        /// </summary>
        /// <param name="numberOfPlayers">The number of players in the game (between 2 and 5 inclusive)</param>
        public ConsoleGame(int numberOfPlayers, IOutputWriter writer)//, bool isConsoleApp)
            : base(numberOfPlayers)//, isConsoleApp)
        {
            if (numberOfPlayers < 2)
                throw new ArgumentException("The number of players must be at least two.");
            if (numberOfPlayers > 5)
                throw new ArgumentException("The number of players must be at most five.");

            Writer = writer;
            Setup(numberOfPlayers);//, isConsoleApp);
            ListHands();
            Writer.WriteLine(Deck.ToString());
            CommandList = GetCommandList();
        }

          /// <summary>
        /// Complete the game by writing the winning message
        /// </summary>
        public override void EndGame()
        {
            Writer.WriteLine(string.Format("Congratulations player {0}, you won the game!", Players.First.Value.Id));
        }

        /// <summary>
        /// Print a message stating which player's turn it is
        /// </summary>
        /// <param name="playerId">The id of the player whose turn it is</param>
        public void PrintTurnMessage(int playerId)
        {
            Writer.WriteLine(string.Format("It's your turn, Player {0}:\n", playerId));
        }

        public void PrintFavorMessage(int playerId)
        {
            Writer.WriteLine(string.Format("Player {0}, you've been asked for a favor. Please select a card:\n", playerId));
        }


        /// <summary>
        /// Get all the available actions that can be played by the player
        /// </summary>
        /// <returns>The action response containing the list of all available actions</returns>
        public ActionResponse GetAvailableActions()
        {
            ActionResponse res = new ActionResponse(Writer);

            foreach (Commands.ICommand command in CommandList)
            {
                res.AddMessage(command.Description);
            }

            return res;
        }

        /// <summary>
        /// Take an action based on the current command entered into the console
        /// </summary>
        public Commands.ICommand GetCommand(string fullCommand, Player currentPlayer)
        {
            string[] commandParts = fullCommand.Split(' ');

            if (commandParts.Length <= 0 || string.IsNullOrEmpty(commandParts[0]))
                return new Commands.UnknownCommand();

            string command = commandParts[0].Trim();

            int targetIndex = 0;
            if (commandParts.Length > 1 && !int.TryParse(commandParts[1], out targetIndex) && targetIndex > 0)
                return new Commands.UnknownCommand();

            switch (Enums.Convert.Command(command))
            {
                case Enums.Command.Hand:
                    return new Commands.HandCommand(currentPlayer);
                case Enums.Command.Draw:
                    return new Commands.DrawCommand(currentPlayer);
                case Enums.Command.Select:
                    return new Commands.SelectCommand(currentPlayer, targetIndex);
                case Enums.Command.Deselect:
                    return new Commands.DeselectCommand(currentPlayer, targetIndex);
                case Enums.Command.Play:
                    return new Commands.PlayCommand(this, currentPlayer, targetIndex);
                case Enums.Command.Give:
                    return new Commands.GiveCommand(this, currentPlayer, targetIndex);
                case Enums.Command.Deck:
                    return new Commands.DeckCommand(Deck);
                case Enums.Command.Status:
                    return new Commands.StatusCommand(currentPlayer);
                case Enums.Command.Help:
                    return new Commands.HelpCommand(this);
                case Enums.Command.Quit:
                    return new Commands.QuitCommand();
                default:
                    return new Commands.UnknownCommand();
            }
        }

        public override void Deal()
        {
            Console.WriteLine("Dealing cards...\n");
            base.Deal();
        }

        private List<Commands.ICommand> GetCommandList()
        {
            return new List<Commands.ICommand>()
            {
                new Commands.HandCommand(),
                new Commands.DrawCommand(),
                new Commands.SelectCommand(),
                new Commands.DeselectCommand(),
                new Commands.PlayCommand(),
                new Commands.GiveCommand(),
                new Commands.DeckCommand(),
                new Commands.StatusCommand(),
                new Commands.HelpCommand(),
                new Commands.QuitCommand()
            };
        }

        private void ListHands()
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(string.Format("Player {0}'s hand:\n----------------\n{1}\n", player.Id, player.Hand.ToString()));
            }
        }
        
        ///// <summary>
        ///// Get the player who has been selected by another player (for giving a card to or playing a card on)
        ///// </summary>
        ///// <param name="playerIndex"></param>
        ///// <returns></returns>
        //public Player GetSelectedPlayer(int playerIndex)
        //{
        //    return Players.Where(p => (p.Id == playerIndex)).DefaultIfEmpty(new NullPlayer()).First();
        //}

        ///// <summary>
        ///// Remove a player from the game when thay pick up an exploding kitten they can't defuse
        ///// </summary>
        ///// <param name="player"></param>
        //public ActionResponse EliminatePlayer(Player player)
        //{
        //    NextPlayer.IsActive = true;
        //    Players.Remove(player);

        //    return new ActionResponse(new Message(Severity.Info, string.Format("Player {0} has been eliminated!", player.Id)));
        //}

        ///// <summary>
        ///// Deal a defuse card to each player then add the remaining cards to the deck and shuffle
        ///// </summary>
        //private void DealDefuseCards()
        //{
        //    Stack<Card> defuseCards = Deck.GetDefuseCards();

        //    foreach (Player player in Players)
        //    {
        //        Card card = defuseCards.Pop();
        //        player.Hand.Cards.Add(card.Id, card);
        //    }

        //    foreach (Card defuseCard in defuseCards)
        //    {
        //        Deck.DrawPile.Push(defuseCard);
        //    }
        //}

        //private void DealInitialCards()
        //{
        //    int initialCards = 4;
        //   
        //    foreach (Player player in Players)
        //    {
        //        for (int dealIndex = 0; dealIndex < initialCards; dealIndex++)
        //        {
        //            if (Deck.DrawPile.Count > 0)
        //            {
        //                Card card = Deck.DrawPile.Pop();
        //                player.Hand.Cards.Add(card.Id, card);
        //            }
        //        }
        //    }
        //}

    }
}
