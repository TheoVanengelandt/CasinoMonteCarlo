using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoMonteCarlo
{
	class CL_croupier
	{
		private List<CL_cards> deck;

		enum Value
		{
			one = 1,
			two = 2,
			three = 3,
			four = 4,
			five = 5,
			six = 6,
			seven = 7,
			heigt = 8,
			nine = 9,
			ten = 10,
			jack = 10,
			quenn = 10,
			king = 10
		}

		internal void GetDeck()
		{
			deck = new CL_cards_games().InitDeck();
		}

		internal void Shuffle()
		{
			deck = deck.OrderBy(a => Guid.NewGuid()).ToList();
		}

		internal void GiveCards(CL_player player1, CL_player player2, CL_player bank)
		{
			// Console.WriteLine("Player 1 a reçu ses cartes");
			player1.GiveCard(deck[0]);
			player1.GiveCard(deck[1]);

			// Console.WriteLine("Player 2 a reçu ses cartes");
			player2.GiveCard(deck[2]);
			player2.GiveCard(deck[3]);

			// Console.WriteLine("La bank a reçu ses cartes");
			bank.GiveCard(deck[4]);
			bank.GiveCard(deck[5]);
			bank.GiveCard(deck[6]);
		}

		public void CountScore(CL_player player)
		{
			// Console.WriteLine("player has: ");

			foreach (CL_cards card in player.hand)
			{
				// Console.Write(card.value + " of " + card.suit + " ");
				Value result = (Value)Enum.Parse(typeof(Value), card.value);
				player.points += (int)result;
			}
			// Console.WriteLine(" in his hand");

			if (player.IsBank)
			{
				if(player.hand[0].suit.Equals(player.hand[1].suit).Equals(player.hand[2].suit))
				{
					// Console.WriteLine("Bonus for bank !!! (3 card of the same suit)");
					player.points += 35;
				}
			}
			else
			{
				if (player.hand[0].suit.Equals(player.hand[1].suit))
				{
					// Console.WriteLine("Bonus for player !!! (2 card of the same suit)");
					player.points += 15;
				}
			}

			player.Score += player.points;

			// Console.WriteLine("His score is " + player.points + " !\n");
		}

		internal void DesignedWinner(CL_player player1, CL_player player2, CL_player bank)
		{
			List<CL_player> playerList = new List<CL_player> {player1, player2, bank};

			List<int> listPoints = new List<int>() { player1.points, player2.points, bank.points };
			listPoints.Sort();

			CL_player winner;

			if (bank.hand[0].value.Equals(bank.hand[1].value).Equals(bank.hand[2].value))
			{
				bank.Victory++;
				// Console.WriteLine("The bank win with 3 identicals cards \n3 " + bank.hand[0].value);
			}
			else
			{
				if(listPoints.FindAll(points => points == listPoints[listPoints.Count - 1]).Count == 1)
				{
					winner = playerList.Find(player => player.points == listPoints[listPoints.Count - 1]);
				}
				else
				{
					List<CL_player> playersWithWinnerScore = playerList.FindAll(player => player.points == listPoints[listPoints.Count - 1]);

					CL_cards higherCard = null;
					int higherCardValue = 0;

					playersWithWinnerScore.ForEach(player => {
						player.hand.ForEach(card =>
						{
							int cardValue = 0;

							switch (card.value)
							{
								case "king":
									cardValue = 13;
									break;
								case "queen":
									cardValue = 12;
									break;
								case "jack":
									cardValue = 11;
									break;
								default:
									Value result = (Value)Enum.Parse(typeof(Value), card.value);
									cardValue = (int)result;
									break;
							}

							if(cardValue > higherCardValue)
							{
								higherCard = card;
							}
						});
					});

					winner = playersWithWinnerScore.Find(player => player.hand.Contains(higherCard));
				}

				winner.Victory++;
				Console.WriteLine("Le gagnant avec un score de " + winner.points + " est " + winner.Name);
			}

			listPoints.Clear();
			playerList.Clear();
		}

		internal void CleanHands(CL_player player1, CL_player player2, CL_player bank)
		{
			player1.ResetHand();
			player2.ResetHand();
			bank.ResetHand();
		}
	}
}
