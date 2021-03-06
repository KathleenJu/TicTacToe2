﻿using System;
using TicTacToe;
using TicTacToe.Enum;
using Xunit;

namespace TicTacToeTests
{
    public class GameShould
    {
        [Fact]
        public void ReturnGameOverWhenThereIsAWinner()
        {
            var game = new Game(new TicTacToeRules());
            var player = new Player(1, 'X');
            
            game.PlayMove(new PlayerMove(player, new Coordinates(1, 1)));
            game.PlayMove(new PlayerMove(player, new Coordinates(0, 2)));
            game.PlayMove(new PlayerMove(player, new Coordinates(2, 0)));
            var gameOver = game.IsGameOver();

            Assert.True(gameOver);
        }
        
        [Fact]
        public void ReturnDrawWhenBoardIsFullAndThereIsNoWinner()
        {
            var game = new Game(new TicTacToeRules());            
            game.PlayMove(new PlayerMove(new Player(1, 'X'), new Coordinates(0, 0)));
            game.PlayMove(new PlayerMove(new Player(2, 'O'), new Coordinates(0, 1)));
            game.PlayMove(new PlayerMove(new Player(1, 'X'), new Coordinates(0, 2)));
            game.PlayMove(new PlayerMove(new Player(2, 'O'), new Coordinates(1, 0)));
            game.PlayMove(new PlayerMove(new Player(2, 'O'), new Coordinates(1, 1)));
            game.PlayMove(new PlayerMove(new Player(1, 'X'), new Coordinates(1, 2)));
            game.PlayMove(new PlayerMove(new Player(2, 'O'), new Coordinates(2, 0)));
            game.PlayMove(new PlayerMove(new Player(1, 'X'), new Coordinates(2, 1)));
            game.PlayMove(new PlayerMove(new Player(2, 'O'), new Coordinates(2, 2)));
            var gameOver = game.IsGameOver();

            Assert.True(gameOver);
            Assert.Null(game.GetWinner());
        }
        
        [Fact]
        public void ReturnTheCorrectWinnerOfTheGame()
        {
            var game = new Game(new TicTacToeRules());            
            var player1 = new Player(1, 'X');
            var player2 = new Player(2, 'O');
            game.PlayMove(new PlayerMove(player1, new Coordinates(1, 2)));
            game.PlayMove(new PlayerMove(player2, new Coordinates(1, 0)));
            game.PlayMove(new PlayerMove(player1, new Coordinates(0, 2)));
            game.PlayMove(new PlayerMove(player2, new Coordinates(2, 1)));
            game.PlayMove(new PlayerMove(player1, new Coordinates(2, 2)));
            
            var gameOver = game.IsGameOver();
            var expectedWinner = game.GetWinner();
            var actualWinner = player1;
            
            Assert.True(gameOver);
            Assert.Equal(expectedWinner, actualWinner);
        }
        
        [Fact]
        public void ReturnPlayerFromTheGamePlayersWhenPlayerIsAddedToTheGame()
        {
            var game = new Game(new TicTacToeRules());
            var player = new Player(1, 'X');
            game.AddPlayerToGame(player);

            Assert.NotEmpty(game.GamePlayers);
            Assert.True(game.GamePlayers.Contains(player));
        }
        
        [Fact]
        public void NotAddPlayerToTheGamePlayersWhenPlayerIsAlreadyAddedToTheGame()
        {
            var game = new Game(new TicTacToeRules());
            var player1 = new Player(1, 'X');
            var player2 = new Player(2, 'X');

            game.AddPlayerToGame(player1);

            Assert.Throws<Exception>(() => game.AddPlayerToGame(player2));
            Assert.NotEmpty(game.GamePlayers);
            Assert.False(game.GamePlayers.Contains(player2));
        }
        
        [Fact]
        public void ReturnTheCorrectCurrentPlayer()
        {
            var game = new Game(new TicTacToeRules());
            var player = new Player(1, 'X');
            game.SetCurrentPlayer(player);

            Assert.True(game.CurrentPlayer.Equals(player));
        }

    }
}