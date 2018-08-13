using ExplodingKittensLib.Models.Players;

namespace ExplodingKittensLib.Models.Cards
{
	public interface ICard
	{
		ActionResponse Play();
		ActionResponse Play(Player player);
	}
}
