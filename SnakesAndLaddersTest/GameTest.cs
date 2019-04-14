using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadders;

namespace SnakesAndLaddersTest
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void OnePlayerTest()
        {
            var game = Game.CreateGame();
            var player = new Player();
            game.AddPlayer(player);
            game.Play();
            Assert.IsTrue(player.HasWon);
        }
    }
}
