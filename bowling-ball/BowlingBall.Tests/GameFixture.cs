using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            var game = new Game();
            Roll(game, 0, 20);
        }

        private Game game;

        public GameFixture()
        {
            game = new Game();
        }
        [TestMethod]
        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
        [TestMethod]
        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
        [TestMethod]
        private void rollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
        [TestMethod]
        private void rollSpare()
        {
            game.Roll(6);
            game.Roll(4);
        }


        [TestMethod]
        public void TestGutterGame()
        {
            rollMany(20, 0);
            Assert.Equals(0, game.Score());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            rollMany(20, 1);
            Assert.Equals(20, game.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            rollSpare();
            game.Roll(4);
            rollMany(17, 0);
            Assert.Equals(18, game.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            game.Roll(10);
            game.Roll(4);
            game.Roll(5);
            rollMany(17, 0);
            Assert.Equals(28, game.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            rollMany(12, 10);
            Assert.Equals(300, game.Score());
        }

        [TestMethod]
        public void TestRandomGameNoExtraRoll()
        {
            game.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.Equals(131, game.Score());
        }

        [TestMethod]
        private void RollSpare()
        {
            game.Roll(6);
            game.Roll(4);
        }
    }
}
