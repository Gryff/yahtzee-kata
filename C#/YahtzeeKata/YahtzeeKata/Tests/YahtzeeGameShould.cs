using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class YahtzeeGameShould
    {
        private YahtzeeGame _game;
        private Category _category1;
        private Category _category2;
        private Category _category3;
        private IConsole _console;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();

            _category1 = Substitute.For<Category>("", null, null, null);
            _category2 = Substitute.For<Category>("", null, null, null);
            _category3 = Substitute.For<Category>("", null, null, null);

            _game = new YahtzeeGame(
                new List<Category> { _category1, _category2, _category3 },
                _console);
        }

        [Test]
        public void PlayAllCategories()
        {
            _game.Play();

            _category1.Received().Play();
            _category2.Received().Play();
            _category3.Received().Play();
        }

        [Test]
        public void Print_final_score_summary()
        {
            _category1.Title.Returns("Ones");
            _category1.Score().Returns(4);
            _category2.Title.Returns("Twos");
            _category2.Score().Returns(2);
            _category3.Title.Returns("Threes");
            _category3.Score().Returns(3);

            _game.Play();

            Received.InOrder(() =>
            {
                _console.PrintLine("Yahtzee score");
                _console.PrintLine("Ones: 4");
                _console.PrintLine("Twos: 2");
                _console.PrintLine("Threes: 3");
                _console.PrintLine("Final score: 9");
            });
        }
    }
}
