using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        private char[,] _board;
        private char _currentPlayer;
        private int _moveCount;

        public char CurrentPlayer
        {
            get { return _currentPlayer; }
        }

        public Board()
        {
            _board = new char[3, 3];
            _currentPlayer = 'X';
            _moveCount = 0;
            InitializeBoard();
        }

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

        public bool IsBoardFull()
        {
            return _moveCount == 9;
        }

        public char this[int row, int col]
        {
            get { return _board[row, col]; }
        }
    }
}
