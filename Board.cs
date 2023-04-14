using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        private char[,] _board; // Represents the Tic-Tac-Toe board as a 2D char array
        private char _currentPlayer; // Represents the current player (either 'X' or 'O')
        private int _moveCount; // Represents the number of moves made so far

        // Returns the current player
        public char CurrentPlayer
        {
            get { return _currentPlayer; }
        }

        // Initializes the board with '-' in every position and sets the first player as 'X'
        public Board()
        {
            _board = new char[3, 3];
            _currentPlayer = 'X';
            _moveCount = 0;
            InitializeBoard();
        }

        // Fills every position of the board with '-'
        private void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    _board[row, col] = '-';
                }
            }
        }

        // Attempts to make a move at the given position (row, col)
        // Returns true if the move is valid and false otherwise
        public bool MakeMove(Tuple<int, int> position)
        {
            int row = position.Item1;
            int col = position.Item2;

            if (_board[row, col] == '-')
            {
                _board[row, col] = _currentPlayer;
                _currentPlayer = (_currentPlayer == 'X') ? 'O' : 'X';
                _moveCount++;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Returns true if the board is full (i.e., all positions have been filled)
        public bool IsBoardFull()
        {
            return _moveCount == 9;
        }

        // Allows indexing into the board using the (row, col) syntax
        public char this[int row, int col]
        {
            get { return _board[row, col]; }
        }
    }
}
