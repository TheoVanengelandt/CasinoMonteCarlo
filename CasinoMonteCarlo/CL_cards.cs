using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoMonteCarlo
{
	class CL_cards
	{
		public string value;
		public string suit;

		public void SetCard(string value, string suit)
		{
			this.value = value;
			this.suit = suit;
		}
	}
}
