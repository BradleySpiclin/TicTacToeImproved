using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        public char GamePiece { get; }

        public Player(char gamePiece)
        {
            GamePiece = gamePiece;
        }
    }
}
