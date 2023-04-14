using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        private Board _board;
        private bool _gameOver;

        public Game()
        {
            // Initialize a new game with a new board and set the game state to not over
            _board = new Board();
            _gameOver = false;
        }

        public void Play()
        {
            while (!_gameOver)
            {
                DisplayBoard();
                Player currentPlayer = GetPlayer();
                bool moveMade = false;

                while (!moveMade)
                {
                    Console.WriteLine($"Player {currentPlayer.GamePiece}, make your move.");
                    Console.Write("Enter row and column number (0-2, separated by a comma): ");

                    string[] input = Console.ReadLine().Split(',');
                    int row, col;

                    try
                    {
                        row = int.Parse(input[0]);
                        col = int.Parse(input[1]);

                        if (row < 0 || row > 2 || col < 0 || col > 2)
                        {
                            throw new ArgumentException("Invalid input. Row and column numbers must be between 0 and 2.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        continue;
                    }

                    moveMade = _board.MakeMove(Tuple.Create(row, col));

                    if (!moveMade)
                    {
                        Console.WriteLine("Invalid move. Please try again.");
                    }
                }

                if (CheckForWinner(currentPlayer))
                {
                    DisplayBoard();
                    Console.WriteLine($"Player {currentPlayer.GamePiece} wins!");
                    _gameOver = true;
                }
                else if (_board.IsBoardFull())
                {
                    DisplayBoard();
                    Console.WriteLine("The game is a tie.");
                    _gameOver = true;
                }
            }
        }
        // Helper method to get the current player based on whose turn it is
        private Player GetPlayer()
        {
            return new Player(_board.CurrentPlayer);
        }
        // Helper method to display the current state of the board to the console
        private void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine("   0 1 2");
            for (int row = 0; row < 3; row++)
            {
                Console.Write($"{row}  ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"{_board[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        // Helper method to check if the current player has won the game
        private bool CheckForWinner(Player player)
        {
            char gamePiece = player.GamePiece;

            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (_board[row, 0] == gamePiece && _board[row, 1] == gamePiece && _board[row, 2] == gamePiece)
                {
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (_board[0, col] == gamePiece && _board[1, col] == gamePiece && _board[2, col] == gamePiece)
                {
                    return true;
                }
            }

            // Check diagonals
            if (_board[0, 0] == gamePiece && _board[1, 1] == gamePiece && _board[2, 2] == gamePiece)
            {
                return true;
            }
            if (_board[0, 2] == gamePiece && _board[1, 1] == gamePiece && _board[2, 0] == gamePiece)
            {
                return true;
            }

            return false;
        }
    }
}
