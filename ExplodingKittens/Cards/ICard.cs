using ExplodingKittens.Players;

namespace ExplodingKittens.Cards
{
	public interface ICard
	{
		ActionResponse Play();
		ActionResponse Play(Player player);
	}
}
