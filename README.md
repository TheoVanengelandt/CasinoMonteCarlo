# CasinoMonteCarlo

## 1 - interview report

“Monte-Carlo’s Casino” front-office uses our services to conceive a simulator. This simulator, must allow them to know if a new game (of their design) will be profitable over time while respecting the legal obligations (such as profit redistribution) .

## 2 - Game description :

The game is played by four players: two players, the bank, and the croupier who represents the bank. The croupier deals two cards (from a deck of 52 cards / 52 = 54 - 2 jokers) to each player. The bank receives three cards. If a player adds up the value of his cards and gets a higher value than the sum of the bank's card values, then the player wins the round. For example, the player is awarded a 10 of heart and a 5 of spades. The player then gets 15 points. If the bank is dealt the 3 of hearts, the 4 of diamonds, and the 5 of clubs, then the player wins the round. If the player gets two cards of the same suit (ex 2 spades), then he is awarded 20 extra points. If the bank gets three similar cards, it always wins the round. The number of runs is unlimited. If the bank gets three cards of the same suit, it is awarded 35 points.

## 3 - Functional specifications

-   The software must simulate the different actors in a game and their interactions.

-   The software must determine if a game can be commercialized by the casino. In order to be marketed the game must allow the casino to win with a rating of 6: 1. In fact, the casino has the obligation to redistribute to the players 75% of the collected bets. Our software must determine if the game created by the casino will fulfill the requirements.

## 4 – Technical Specifications

For deployment
▪ Target Client : DELL Latitude D505
▪ RAM : 2G running at 1.18GHZ
▪ CPU : Intel Core 2 Duo
▪ Usual RAM use: 1.5 G available.
▪ Usual use of the CPU : 2%

For the performances :
▪ Maximal execution time for 10.000 drawings: 60 seconds with an exit Release.

For development :
▪ IDE : VS
▪ Net Framework : 4.0 or sup
▪ Language : C# 4.0 or sup
▪ Name space : System.Threading
▪ Library : Task Parallel Library

# Architect guidelines

## 1 - Software structure: Use of 5 classes and one interface.

· CL_cards
· CL_croupier
· CL_cards_games
· CL_player + Iplayer
· Program

## 2 – Modeling of the « Round » Activity

The croupier takes a deck of cards
The croupier shuffles the cards
The croupier distributes the cards to the player
The croupiers counts the number of points of the bank and the players
The croupier designates the bank or one of the players as winner of the round

## 3 – Modeling of the "Monte Carlo Resolution" activity

“Round” activity
Loop => {round X 10 000}
Scoring for the bank, player 1 and player 2
Score display

## 4 – Modeling « decision making » activity

Score display and odds ratio calculation. Decision making.

## 5 – Technical constraints of the general activity:

Threads :
▪ Main: Execution of a program ::main. Recording points and displaying time. Launch secondary threads.
▪ T1: Execution of any instruction encapsulating the "round" activity on 10000 iterations. Parallelizable code construction on n-processors to meet technical specifications. Issue of an end event at the end of treatment.
▪ T2: Time control and time display when the event is raised by T1.
· Random Sequence: Based on the milliseconds of the hosting device.
