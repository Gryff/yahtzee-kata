using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class YahtzeeFeature
    {
        private Dice _dice;
        private IConsole _console;
        private List<Category> _categories;
        private ScoreCard _scoreCard;
        private YahtzeeGame _game;
        private Random _numberGenerator;
        private Turn _turn;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();

            _numberGenerator = Substitute.For<Random>();
            _numberGenerator.Next(1, 7).Returns(
                // first category
                1, 2, 3, 4, 5, 
                1, 1, 2, 3, 
                1, 2,
                // second category
                2, 2, 1, 3, 2,
                4, 4,
                2, 1);

            _console.ReadLine().Returns(
                // first category
                "D2 D3 D4 D5",
                "D4 D5",
                // second category
                "D3 D4",
                "D3 D4");

            _dice = new Dice(5, _numberGenerator);
            _turn = new Turn(_dice, _console);

            _categories = new List<Category>
            {
                new Category("Ones", _console, _turn),
                new Category("Twos", _console, _turn),
                new Category("Threes", _console, _turn)
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
                _console.PrintLine("Dice: D1:1 D2:2 D3:3 D4:4 D5:5");
                _console.PrintLine("[1] Dice to re-run:");
                _console.PrintLine("Dice: D1:1 D2:1 D3:1 D4:2 D5:3");
                _console.PrintLine("[2] Dice to re-run:");
                _console.PrintLine("Dice: D1:1 D2:1 D3:1 D4:1 D5:2");
                _console.PrintLine("Category Ones score: 4");

                _console.PrintLine("Category: Twos");
                _console.PrintLine("Dice: D1:2 D2:2 D3:1 D4:3 D5:2");
                _console.PrintLine("[1] Dice to re-run:");
                _console.PrintLine("Dice: D1:2 D2:2 D3:4 D4:4 D5:2");
                _console.PrintLine("[2] Dice to re-run:");
                _console.PrintLine("Dice: D1:2 D2:2 D3:2 D4:1 D5:2");
                _console.PrintLine("Category Twos score: 4");

                _console.PrintLine("Category: Threes");
            });
        }
    }
}
