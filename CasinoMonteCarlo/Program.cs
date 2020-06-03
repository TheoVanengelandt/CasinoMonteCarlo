using CasinoMonteCarlo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyFirstCoreApp
{
	public class Program
	{
		private static CL_croupier croupier;

		private static CL_player player1;
		private static CL_player player2;
		private static CL_player bank;

		public static void Main(string[] args)
		{
			Console.WriteLine("Casino Monte-Carlo game start");
			Play();
		}

		private static void Play()
		{
			Console.WriteLine("Les joueurs se préparent...");

			// Init croupier instance
			croupier = new CL_croupier();

			// Init player instance
			player1 = new CL_player
			{
				Name = "Player 1"
			};
			player2 = new CL_player()
			{
				Name = "Player 2"
			};

			// Init bank instance
			bank = new CL_player
			{
				Name = "Bank",
				IsBank = true
			};

			Console.WriteLine("Les joueurs sont pret !");
			Console.WriteLine("Début de la partie !");

			DateTime startTime = DateTime.Now;

			int roundNumber = 10000;

			for(int r = 0; r < roundNumber; r++)
			{
				Console.WriteLine("\nDébut de la manche " + (r+1).ToString() + " !");
				Round();
			}

			Console.WriteLine("P1 a un score de " + player1.Score + " et " + player1.Victory + " victoires");
			Console.WriteLine("P2 a un score de " + player2.Score + " et " + player2.Victory + " victoires");
			Console.WriteLine("bank a un score de " + bank.Score + " et " + bank.Victory + " victoires");

			TimeSpan duration = DateTime.Now - startTime;
			Console.WriteLine("Durée de la partie " + duration.Minutes.ToString() + "m " + duration.Seconds.ToString() + "s " + duration.Milliseconds.ToString() + "ms\n");

			Console.ReadKey();
		}

		private static void Round()
		{
			Console.WriteLine("Préparation du jeu");
			croupier.GetDeck();

			Console.WriteLine("Le croupier mélange le jeu...");
			croupier.Shuffle();

			Console.WriteLine("Le croupier distribue les cartes aux joueurs...");
			croupier.GiveCards(player1, player2, bank);

			Console.WriteLine("Decompte des scores...");
			croupier.CountScore(player1);
			croupier.CountScore(player2);
			croupier.CountScore(bank);

			Console.WriteLine("P1 a " + player1.points + " points");
			Console.WriteLine("P2 a " + player2.points + " points");
			Console.WriteLine("bank a " + bank.points + " points");

			croupier.DesignedWinner(player1, player2, bank);

			Console.WriteLine("Le Croupier ramasse les cartes");
			croupier.CleanHands(player1, player2, bank);

			Console.WriteLine("Manche terminée ! ");
		}
	}
}