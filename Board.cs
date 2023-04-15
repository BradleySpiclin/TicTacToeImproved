using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        private static readonly int _rows = 4;
        private static readonly int _columns = 4;
        private const int MaxMoveCount = 16;
        private const char Empty = '-';
        private char[,] _board; // Represents the Tic-Tac-Toe board as a 2D char array
        private char _currentPlayer; // Represents the current player (either 'X' or 'O')
        private int _moveCount; // Represents the number of moves made so far
        private readonly Dictionary<Tuple<int, int>, bool> _availablePositions = new();

        // Returns the current player
        public char CurrentPlayer
        {
            get { return _currentPlayer; }
        }
        public int GetMoveCount 
        {
            get { return _moveCount; }
        }
        public int GetMaxMoveCount 
        {
            get { return MaxMoveCount; }
        }

        // Initializes the board with '-' in every position and sets the first player as 'X'
        public Board()
        {
            _board = new char[_rows, _columns];
            _currentPlayer = 'X';
            _moveCount = 0;
            InitializeBoard();
            InitializeAvailablePositions();
        }

        // Initializes the availability of each grid space
        private void InitializeAvailablePositions()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _columns; col++)
                {
                    _availablePositions[new Tuple<int, int>(row, col)] = true;
                }
            }
        }

        // Fills every position of the board with '-'
        private void InitializeBoard()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _columns; col++)
                {
                    _board[row, col] = Empty;
                }
            }
        }
        public void SetElement(int row, int col, char value)
        {
            _board[row, col] = value;
        }

        // Attempts to make a move at the given position (row, col)
        // Returns true if the move is valid and false otherwise
        public bool MakeMove(Tuple<int, int> position)
        {
            int row = position.Item1 - 1;
            int col = position.Item2 - 1;

            if (_board[row, col] == Empty)
            {
                _board[row, col] = _currentPlayer;
                _availablePositions[new Tuple<int, int>(row, col)] = false;
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
            return _moveCount == MaxMoveCount;
        }

        public void ResetGridSpace(Tuple<int, int> position)
        {
            int row = position.Item1;
            int col = position.Item2;

            _board[row, col] = Empty;
        }
        // Allows indexing into the board using the (row, col) syntax
        public char this[int row, int col]
        {
            get { return _board[row, col]; }
        }
    }
}
