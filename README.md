# Tic-Tac-Toe Game

This is a simple command-line implementation of the classic game Tic-Tac-Toe. The game allows two players to take turns marking spaces on a 3x3 grid, with the objective of getting three in a row horizontally, vertically, or diagonally.

Board
-
The Board class represents the game board and keeps track of the state of the game. It has a 2D array of char to represent the board and methods to make a move, check if a move is valid, and check if the board is full.

Game
-
The Game class orchestrates the game and handles player input, game logic, and output to the console. It has a Board object and a boolean variable to represent whether the game is over. The Play() method starts the game loop.

Player
-
The Player class represents a player in the game and has a char property to represent the player's game piece.

Usage
-
To play the game, simply run the Program.cs file. The game will be played in the console. Two players will take turns entering row and column numbers to place their game piece on the board. The game ends when a player gets three in a row or the board is full. Players can choose to play again after the game ends.
