using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class YahtzeeFeature
    {
        private Dice _die;
        private IConsole _console;
        private List<Category> _categories;
        private ScoreCard _scoreCard;
        private YahtzeeGame _game;
        private Random _random;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();

            _random = Substitute.For<Random>();
            _random.Next(1, 7).Returns(1, 2, 3, 4, 5, 1, 1, 2, 3, 1, 2);

            _die = new Dice(5);

            _categories = new List<Category>
            {
                new Category("Ones", _console, _die),
                new Category("Twos", _console, _die),
                new Category("Threes", _console, _die)
            };

            _scoreCard = new ScoreCard(_categories);
            _game = new YahtzeeGame(_scoreCard);
        }

        [Test]
        public void PlayThreeRounds()
        {
            _game.Run();

            Received.InOrder(() =>
            {
                _console.PrintLine("Category: Ones");
                _console.PrintLine("Die: D1:1 D2:2 D3:3 D4:4 D5:5");
                _console.PrintLine("[1] Die to re-run:");
                _console.PrintLine("Die: D1:1 D2:1 D3:1 D4:2 D5:3");
                _console.PrintLine("[2] Die to re-run:");
                _console.PrintLine("Die: D1:1 D2:1 D3:1 D4:1 D5:2");
                _console.PrintLine("Category Ones score: 4");

                _console.PrintLine("Category: Twos");
                _console.PrintLine("Category: Threes");
            });
        }
    }
}
