﻿using ExplodingKittensLib.Models.Players;
using System;

namespace ExplodingKittensLib.Models.Cards
{
	public class NullCard : Card
	{
		public NullCard()
			: base(null, 0, "Null card")
		{
		}

		public override ActionResponse Play()
		{
			throw new InvalidOperationException("You don't have that card.");
		}

		public override ActionResponse Play(Player player)
		{
			throw new NotImplementedException();
		}
	}
}
