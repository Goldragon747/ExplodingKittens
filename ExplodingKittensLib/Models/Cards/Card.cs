using ExplodingKittensLib.Models.Players;

namespace ExplodingKittensLib.Models.Cards
{
	public abstract class Card : ICard
	{
		public Game Game { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public string TagLine { get; set; }
		public string Explanation { get; set; }
		public bool IsSelected { get; set; }

		public Card() { }

		public Card(Game game, int id, string name)
		{
			Game = game;
			Id = id;
			Name = name;
		}

		public Card(Game game, int id, string name, string explanation)
			: this(game, id, name)
		{
			Explanation = explanation;
		}

		public Card(Game game, int id, string name, string tagLine, string explanation)
			: this(game, id, name, explanation)
		{
			TagLine = tagLine;
		}

		public override string ToString()
		{
			return string.Format("{0:00}. {1}: {2} {{{3}}}", Id, Name, TagLine, Explanation);
		}

		public abstract ActionResponse Play(Player player);

		public abstract ActionResponse Play();
	}
}
