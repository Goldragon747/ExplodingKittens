using System;
using ExplodingKittensLib.Models.Enums;

namespace ExplodingKittensLib.Models.Commands
{
	public class QuitCommand : ICommand
	{
		public Command CommandType { get { return Command.Quit; } }

		public string Description
		{
			get { return string.Format("\"{0}\": Quit the game.", CommandType); }
		}

		public ActionResponse Execute()
		{
			Environment.Exit(0);

			return new ActionResponse();
		}
	}
}
