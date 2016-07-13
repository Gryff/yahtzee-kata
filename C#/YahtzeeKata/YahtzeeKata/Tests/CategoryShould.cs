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
        private Turn _turn;
        private Rule _rule;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();
            _title1 = "Ones";
            _turn = Substitute.For<Turn>(null, _console);
            _rule = Substitute.For<Rule>("", null);
            _category = new Category(_rule, _console, _turn);
        }

        [Test]
        public void PrintItsTitle()
        {
            _rule.Name.Returns(_title1);
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
            var dice = new [] {1, 1, 1, 2, 3};

            _turn.GetDice().Returns(dice);

            _rule.Name.Returns(_title1);
            _rule.Score(dice).Returns(3);

            _category.Play();

            _console.Received().PrintLine($"Category {_title1} score: 3");
        }
    }
}
