using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class CategoryShould
    {
        private IConsole _console;
        private Category _category;
        private string _title;
        private Turn _turn;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();
            _title = "Ones";
            _turn = Substitute.For<Turn>(null, _console);
            _category = new Category(_title, _console, _turn);
        }

        [Test]
        public void PrintItsTitle()
        {
            _category.Play();

            _console.Received().PrintLine($"Category: {_title}");
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

            _console.Received().PrintLine($"Category {_title} score: 3");
        }
    }
}
