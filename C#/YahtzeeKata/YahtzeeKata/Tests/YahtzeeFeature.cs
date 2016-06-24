using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class YahtzeeFeature
    {
        private List<Dice> _die;
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
            _die = Enumerable.Repeat(new Dice(_random), 5).ToList();

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
                _console.PrintLine("Category: Twos");
                _console.PrintLine("Category: Threes");
            });
        }
    }
}
