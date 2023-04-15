# Tic-Tac-Toe Improved

This is an improved version of the common Tic-Tac-Toe game. Two players take turns to mark spaces on a 4x4 grid, with the objective of getting four in a row horizontally, vertically, or diagonally. An added twist of a wildcard character '*' can appear anywhere in an unoccupied grid after the first move is made and shifts to a new location after every player move. The wildcard character persists until there is only one available grid space remaining.

Board
-
The Board class represents the game board and keeps track of the state of the game. It has a 2D array of char to represent the board and methods to make a move, check if a move is valid, and check if the board is full. Board also contains a Dictionary of Tuple and Boolean which is used to track which grids hav been visited by a player and this provides the ability to insert a wildcard character at an unvisted grid space.

Game
-
The Game class orchestrates the game and handles player input, game logic, and output to the console. It has a Board object and a boolean variable to represent whether the game is over. The Play() method starts the game loop.

Player
-
The Player class represents a player in the game and has a char property to represent the player's game piece.

Usage
-
To play the game, simply run the Program.cs file. The game will be played in the console. Two players will take turns entering row and column numbers to place their game piece on the board. The game ends when a player gets four in a row or the board is full. Players can choose to play again after the game ends.
