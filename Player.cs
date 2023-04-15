using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        // Property to get the game piece (X or O) of the player
        public char GamePiece { get; } 

        public Player(char gamePiece)
        {
            GamePiece = gamePiece;
        }
    }
}
