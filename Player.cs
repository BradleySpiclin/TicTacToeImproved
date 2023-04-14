using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        public char GamePiece { get; } // Property to get the game piece (X or O) of the player

        public Player(char gamePiece) // Constructor to create a new player with a specified game piece
        {
            GamePiece = gamePiece;
        }
    }
}
