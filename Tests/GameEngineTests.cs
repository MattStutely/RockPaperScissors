using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RockPaperScissors;

namespace Tests
{
    [TestFixture]
    public class GameEngineTests
    {
        private GameEngine _gameEngine;

        [SetUp]
        public void SetupTests()
        {
            _gameEngine=new GameEngine();    
        }

        [Test]
        public void NaNCheck()
        {
            Assert.That(_gameEngine.IsAnInteger("1"));
            Assert.That(!_gameEngine.IsAnInteger("x"));
        }

        [Test]
        public void CheckComputerCreatesValidResponse()
        {
            var response = _gameEngine.GetComputerResponse();
            Assert.That(response!=null);
        }

        [Test]
        public void CheckPlayer1Win()
        {
            var outcome = _gameEngine.PlayerOneGameOutcome(1, 0);
            Assert.That(outcome==GameEngine.Outcome.Win);
        }

        [Test]
        public void TestRockBehavesCorrectly()
        {
            Assert.That(_gameEngine.FirstResponseOutcome(GameEngine.Response.Rock, GameEngine.Response.Scissors)==GameEngine.Outcome.Win);
            Assert.That(_gameEngine.FirstResponseOutcome(GameEngine.Response.Rock, GameEngine.Response.Paper) == GameEngine.Outcome.Lose);
            Assert.That(_gameEngine.FirstResponseOutcome(GameEngine.Response.Rock, GameEngine.Response.Rock) == GameEngine.Outcome.Draw);
        }

        [Test]
        public void TestPaperBehavesCorrectly()
        {
            Assert.That(_gameEngine.FirstResponseOutcome(GameEngine.Response.Paper, GameEngine.Response.Scissors) == GameEngine.Outcome.Lose);
            Assert.That(_gameEngine.FirstResponseOutcome(GameEngine.Response.Paper, GameEngine.Response.Paper) == GameEngine.Outcome.Draw);
            Assert.That(_gameEngine.FirstResponseOutcome(GameEngine.Response.Paper, GameEngine.Response.Rock) == GameEngine.Outcome.Win);
        }


        [Test]
        public void TestScissorsBehavesCorrectly()
        {
            Assert.That(_gameEngine.FirstResponseOutcome(GameEngine.Response.Scissors, GameEngine.Response.Scissors) == GameEngine.Outcome.Draw);
            Assert.That(_gameEngine.FirstResponseOutcome(GameEngine.Response.Scissors, GameEngine.Response.Paper) == GameEngine.Outcome.Win);
            Assert.That(_gameEngine.FirstResponseOutcome(GameEngine.Response.Scissors, GameEngine.Response.Rock) == GameEngine.Outcome.Lose);
        }

        [Test]
        public void CheckPlayer1Lose()
        {
            var outcome = _gameEngine.PlayerOneGameOutcome(0,1);
            Assert.That(outcome == GameEngine.Outcome.Lose);
        }

        [Test]
        public void CheckPlayer1Draw()
        {
            var outcome = _gameEngine.PlayerOneGameOutcome(1, 1);
            Assert.That(outcome == GameEngine.Outcome.Draw);
        }

        [Test]
        public void CheckNumberOfGamesWithAcceptableNumber()
        {
            bool outcome = _gameEngine.ValidNumberOfGames(5, 7);
            Assert.That(outcome==true);
        }

        [Test]
        public void CheckNumberOfGamesWithUncceptableNumber()
        {
            bool outcome = _gameEngine.ValidNumberOfGames(7, 5);
            Assert.That(outcome == false);
        }
        
        [Test]
        public void CheckNumberOfGamesWithZero()
        {
            bool outcome = _gameEngine.ValidNumberOfGames(0, 5);
            Assert.That(outcome == false);
        }

        [Test]
        public void CheckCorrectResponseForRock()
        {
            var response = _gameEngine.GetResponseFromEnteredString("r");
            Assert.That(response==GameEngine.Response.Rock);
        }

        [Test]
        public void CheckCorrectResponseForPaper()
        {
            var response = _gameEngine.GetResponseFromEnteredString("p");
            Assert.That(response == GameEngine.Response.Paper);
        }

        [Test]
        public void CheckCorrectResponseForScissors()
        {
            var response = _gameEngine.GetResponseFromEnteredString("s");
            Assert.That(response == GameEngine.Response.Scissors);
        }

        [Test]
        public void CheckCorrectResponseForOther()
        {
            var response = _gameEngine.GetResponseFromEnteredString("q");
            Assert.That(response == null);
        }

    }
}
