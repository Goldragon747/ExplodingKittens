﻿
namespace ExplodingKittensLib.Models.Commands
{
	public class HelpCommand : ICommand
	{
		public Game Game { get; set; }

		public string Description
		{
			get { return string.Format("\"{0}\": List all the available commands.", CommandType); }
		}

		public Enums.Command CommandType
		{
			get { return Enums.Command.Help; }
		}

		public HelpCommand()
		{
		}

		public HelpCommand(Game game)
		{
			Game = game;
		}

		public ActionResponse Execute()
		{
			return Game.GetAvailableActions();
		}
	}
}
