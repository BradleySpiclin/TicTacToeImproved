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
        // constants
        private const int MinimumMoveValue = 1;
        private const int MaximumMoveValue = 4;
        private const char Wildcard = '*';
        // Fields
        private Board _board;
        private bool _gameOver;
        private Tuple<int, int>? _currentWildcard = null;

        public Game() // Initialize a new game with a new board and set the game state to not over
        {
            _board = new Board();
            _gameOver = false;
        }
        // Main game loop
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
                    Console.Write("Enter row and column number (1-4, separated by a comma): ");
                    var input = Console.ReadLine();
                    if (input == null)
                    {
                        Console.WriteLine("Input cannot be null.");
                        continue;
                    }
                    int row, col;
                    try
                    {
                        string[] values = input.Split(',');
                        if (values.Length != 2)
                        {
                            throw new ArgumentException("Invalid input. Row and column numbers must be separated by a comma.");
                        }
                        row = int.Parse(values[0]);
                        col = int.Parse(values[1]);
                        if (row < MinimumMoveValue || row > MaximumMoveValue || col < MinimumMoveValue || col > MaximumMoveValue)
                        {
                            throw new ArgumentException($"Invalid input. Row and column numbers must be between {MinimumMoveValue} and {MaximumMoveValue}.");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        continue;
                    }
                    catch (ArgumentException ex)
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
                RemoveWildCard(); // Removes the current wildcard character '*'
                AddWildCard(); // Adds a random wildcard character '*' to an available grid space
            }
        }
        public void AddWildCard()
        {
            Random random = new Random();
            int row = random.Next(0, 4);
            int col = random.Next(0, 4);

            // Check if the random position is already occupied by a game piece
            while (!_board.GetAvailablePosition(row, col))
            {
                row = random.Next(0, 4);
                col = random.Next(0, 4);
            }
            if (_board.GetMoveCount < _board.GetMaxMoveCount - 1) 
            {
                _currentWildcard = new Tuple<int, int>(row, col);
                _board.SetElement(row, col, Wildcard);
            }
        }
        // Helper method to remove the current wildcard '*' from the grid
        public void RemoveWildCard()
        {
            if (_currentWildcard != null) 
            {
                _board.ResetGridSpace(_currentWildcard);
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
            Console.WriteLine("   1 2 3 4");
            for (int row = 0; row < 4; row++)
            {
                Console.Write($"{row + 1}  ");
                for (int col = 0; col < 4; col++)
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
            for (int row = 0; row < 4; row++)
            {
                if (_board[row, 0] == gamePiece && _board[row, 1] == gamePiece && _board[row, 2] == gamePiece && _board[row, 3] == gamePiece)
                {
                    return true;
                }
            }
            // Check columns
            for (int col = 0; col < 4; col++)
            {
                if (_board[0, col] == gamePiece && _board[1, col] == gamePiece && _board[2, col] == gamePiece && _board[3, col] == gamePiece)
                {
                    return true;
                }
            }
            // Check diagonals
            if (_board[0, 0] == gamePiece && _board[1, 1] == gamePiece && _board[2, 2] == gamePiece && _board[3, 3] == gamePiece)
            {
                return true;
            }
            if (_board[0, 3] == gamePiece && _board[1, 2] == gamePiece && _board[2, 1] == gamePiece && _board[3, 0] == gamePiece)
            {
                return true;
            }
            return false;
        }
    }
}
