using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Library
{
    public class Game
    {
        // Board positions, 0 is included, because it makes the usage for me easier, because pos[1] is field 1
        private static readonly string[] Position = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        /*
         * Initiates the game
         * First - players are asked to choose their name
         * Second - pieces and scores are set
         * Third - loop starting to start the game (stops if game is over)
         */
        public Game()
        {
            string[] players = SetPlayers();
            string[] pieces = { "O", "X" };
            int[] scores = { 0, 0 };

            bool playing = true;
            while (playing)
            {
                PlayGame(players, scores, pieces);
                playing = AskToPlayAgain();
            }
        }

        private static void DrawBoard()
        {
            Console.WriteLine();
            Console.WriteLine("   {0}  |  {1}  |  {2}", Position[1], Position[2], Position[3]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}", Position[4], Position[5], Position[6]);
            Console.WriteLine("-------------------");
            Console.WriteLine("   {0}  |  {1}  |  {2}", Position[7], Position[8], Position[9]);
            Console.WriteLine();
        }

        private static void PlayGame(string[] players, int[] scores, string[] pieces)
        {
            bool isGameWon = false;
            int playerIndex = 0;

            // Check if game is not over
            while (isGameWon == false)
            {
                // name of current player
                var player = players[playerIndex];
                // nextPlayerIndex is 1 - the current playerIndex (so there is always a swap between 0 and 1)
                var nextPlayerIndex = 1 - playerIndex;
                // piece of current player (either O or X)
                var piece = pieces[playerIndex];
                // piece of next player (either O or X)
                var opponentPiece = pieces[nextPlayerIndex];

                MakeMove(players, scores, player, piece, opponentPiece);

                isGameWon = CheckWin();

                // if the game is not over, it continues onto the next player
                if (!isGameWon)
                {
                    playerIndex = nextPlayerIndex;
                }
            }

            Console.Clear();
            DrawBoard();
            Reset();

            // Checks if the game is over
            if (isGameWon)
            {
                // Increments the score of the winning player
                IncrementPlayerScore(scores, playerIndex);
                Console.WriteLine("{0} wins!", players[playerIndex]);
                Console.WriteLine();
            }
            // If there is no winner, it's a draw
            else
            {
                Console.WriteLine("It's a draw!");
            }

            // Draw the current scores
            ShowScoreboard(players, scores);
        }

        // Ask the players for their name and who goes first
        private static string[] SetPlayers()
        {
            Console.WriteLine("Please enter the name of player 1.");
            // Read input of player1
            var player1 = Console.ReadLine();
            Console.WriteLine("Please enter the name of player 2.");
            // Read input of player2
            var player2 = Console.ReadLine();

            Console.WriteLine("{0} is O and {1} is X.", player1, player2);
            Console.WriteLine("{0} goes first.", player1);
            Console.ReadLine();
            Console.Clear();

            // Return new String with the new names
            return new[] { player1, player2 };
        }

        /*
         * takes 5 inputs
         * players and scores for the scoreboard
         * player, piece and opponentPiece to check if the player has made a move yet
         */
        private static void MakeMove(string[] players, int[] scores, string player, string piece, string opponentPiece)
        {
            do
            {
                Console.Clear();
                // Redraw the board
                DrawBoard();
                // Redraw the current score
                ShowScoreboard(players, scores);
            } 
            // Loop while the opponent has not picked his field
            while (!SetPiece(player, piece, opponentPiece));
        }

        // Show current score of both players
        private static void ShowScoreboard(string[] players, int[] scores)
        {
            Console.WriteLine("--- Scores ---");
            Console.WriteLine("{0} - {1}", players[0], scores[0]);
            Console.WriteLine("{0} - {1}", players[1], scores[1]);
            Console.WriteLine();
        }

        private static bool SetPiece(string player, string playerPiece, string opponentsPiece)
        {
            // Shows which turn it is and their piece
            Console.WriteLine("{0}'s ({1}) turn", player, playerPiece);
            // Returns a number between 1 and 9 which is the requested field to place a piece on
            var position = AskTheUser("Which position would you like to take?", 1, 9);
            // Checks if the requested position by the player is taken
            if (!IsPositionTaken(playerPiece, opponentsPiece, position))
            {
                Position[position] = playerPiece;
                return true;
            }

            Console.WriteLine("That positions is already taken!");
            Console.ReadLine();
            Console.Clear();
            return false;
        }

        // Checks if the a position is taken - returns true if O or X is already placed
        private static bool IsPositionTaken(string playerPiece, string opponentsPiece, int position)
        {
            return Position[position] == opponentsPiece || Position[position] == playerPiece;
        }

        private static bool AskToPlayAgain()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("1. Play again");
            Console.WriteLine("2. Exit game");
            Console.WriteLine("----------------");

            // Returns number between 1 and 2
            var choice = AskTheUser("Enter: ", 1, 2);

            Console.Clear();
            if (choice == 1)
            {
                return true;
            } 
            else
            {
                Console.WriteLine("Thanks for playing!");
                Console.WriteLine("by Pascal Schmiedjell");
                return false;
            }
        }

        /* 
         * 3 inputs (message, min and max)
         * returns a number between min and max
         */
        private static int AskTheUser(string message, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();
                bool isNumeric = int.TryParse(input, out int choice);

                if (isNumeric && (choice >= min && choice <= max))
                {
                    return choice;
                }
            }
        }

        // Checks if the game is won
        static bool CheckWin()
        {
            bool diagonal = IsLine(1, 4) || IsLine(3, 2);
            bool horizontal = IsHorizontalLine(1) || IsHorizontalLine(4) || IsHorizontalLine(7);
            bool vertical = IsVerticalLine(1) || IsVerticalLine(2) || IsVerticalLine(3);
            return diagonal || horizontal || vertical;
        }

        // resets the board positions to their default value
        private static void Reset()
        {
            for (int i = 1; i < 10; i++)
            {
                Position[i] = i.ToString();
            }
        }

        /* 
         * takes a score array e.g. {1,2} and a playernumber
         * (for this game there is only player 0 and player 1)
         */
        private static void IncrementPlayerScore(int[] scores, int playerIndex)
        {
            scores[playerIndex] = scores[playerIndex] + 1;
        }

        /* 
         * baseline for line checking
         * 4 inputs taken - 3 positions and the piece
         */
        private static bool IsLine(int position1, int position2, int position3, string piece)
        {
            //if there are 3 pieces of the same person, true is returned
            return Position[position1] == piece && Position[position2] == piece && Position[position3] == piece;
        }

        private static bool IsLine(int start, int step)
        {
            /* 
             * there is a start value and a step value
             * e.g 3 checks for vertical lines and 1 checks for horizontal lines
             * takes the start value and checks what piece is in that position
             */
            return IsLine(start, start + step, start + (2 * step), Position[start]);
        }

        /*
         * Checks if it is a horizontal line starting from a position
         * like e.g. 1 - checks if - 1,2,3 and the piece are in the same line - if so, it returns true
         */
        private static bool IsHorizontalLine(int start)
        {
            return IsLine(start, 1);
        }

        /*
         * Checks if it is a vertical line starting a position
         * like e.g. 1 - checks if - 1,4,7 and the piece are in the same line - if so, it returns true
         */
        private static bool IsVerticalLine(int start)
        {
            return IsLine(start, 3);
        }
    }
}
