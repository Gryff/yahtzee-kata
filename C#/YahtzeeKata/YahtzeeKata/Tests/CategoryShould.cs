using System;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class CategoryShould
    {
        private IConsole _console;
        private Category _category;
        private string _title1;
        private Func<int[], int> _scoreDecider;
        private Turn _turn;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();
            _title1 = "Ones";
            _scoreDecider = dice => dice.Count(d => d == 1);
            _turn = Substitute.For<Turn>(null, _console);
            _category = new Category(_title1, _scoreDecider, _console, _turn);
        }

        [Test]
        public void PrintItsTitle()
        {
            _category.Play();

            _console.Received().PrintLine($"Category: {_title1}");
        }

        [Test]
        public void PlayTurns()
        {
            _category.Play();

            _turn.Received().PlayFirstTurn();

            _turn.Received(2).PlayAnotherTurn();
        }

        [Test]
        public void PrintTheFinalScore()
        {
            _turn.GetDice().Returns(new [] {1, 1, 1, 2, 3});

            _category.Play();

            _console.Received().PrintLine($"Category {_title1} score: 3");
        }
    }
}
