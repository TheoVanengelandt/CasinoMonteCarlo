using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoMonteCarlo
{
	class CL_cards_games
	{
		private List<CL_cards> deck;

		public List<CL_cards> InitDeck()
		{
			deck = new List<CL_cards>();

			List<string> values = new List<string>() {"one", "two", "three", "four", "five", "six", "seven", "heigt", "nine", "ten", "jack", "queen", "king" };
			List<string> suits = new List<string>() { "Hearts", "Diamonds", "Clubs", "Spades" };

			suits.ForEach(suit => values.ForEach(value => {
				CL_cards card = new CL_cards();
				card.SetCard(value, suit);

				// Console.WriteLine(card.value + " of " + card.suit + " added");
				deck.Add(card);
			}));

			// Console.WriteLine(deck.Count.ToString(), " cartes ont été ajoutées");
			return deck;
		}
	}
}
