using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class ScoreCardShould
    {
        private Category _category;
        private Category _category2;
        private ScoreCard _scoreCard;
        private IConsole _console;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();
            _category = Substitute.For<Category>(null, null, null);
            _category2 = Substitute.For<Category>(null, null, null);

            _scoreCard = new ScoreCard(
                new List<Category> { _category, _category2 },
                _console);
        }

        [Test]
        public void PlayTheNextCategory()
        {
            _scoreCard.PlayCategories();

            _category.Received().Play();
            _category2.Received().Play();
        }

        [Test]
        public void PrintTheFinalScore()
        {
            _category.FormatScore().Returns("Ones: 4");
            _category2.FormatScore().Returns("Twos: 2");

            _category.GetScore().Returns(4);
            _category2.GetScore().Returns(2);

            _scoreCard.PrintScore();

            Received.InOrder(() =>
            {
                _console.PrintLine("Yahtzee score");
                _console.PrintLine("Ones: 4");
                _console.PrintLine("Twos: 2");
                _console.PrintLine("Final score: 6");
            });
        }
    }
}
