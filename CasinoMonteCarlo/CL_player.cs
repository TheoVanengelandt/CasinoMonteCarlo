using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoMonteCarlo
{
	class CL_player
	{
		public string Name { get; set; }
		public bool IsBank { get; set; }
		public int Score { get; set; }
		public int Victory { get; set; } = 0;

		public List<CL_cards> hand = new List<CL_cards>();

		public int points =  0;

		public void GiveCard(CL_cards card)
		{
			hand.Add(card);
		}

		public void ResetHand()
		{
			hand.Clear();
			points = 0;
		}
	}
}
