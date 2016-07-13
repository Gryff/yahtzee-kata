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
        private IConsole _console;
        private YahtzeeGame _game;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();

            var numberGenerator = Substitute.For<Random>();
            numberGenerator.Next(1, 7).Returns(
                // first category
                1, 2, 3, 4, 5, 
                1, 1, 2, 3, 
                1, 2,
                // second category
                2, 2, 1, 3, 2,
                4, 4,
                2, 1,
                // third category
                1, 2, 3, 4, 5,
                3, 1, 2, 4,
                5, 1, 2);

            _console.ReadLine().Returns(
                // first category
                "D2 D3 D4 D5",
                "D4 D5",
                // second category
                "D3 D4",
                "D3 D4",
                // third category
                "D1 D2 D4 D5",
                "D2 D4 D5");

            var categories = new List<Category>
            {
                new Category(new Rule("Ones", DiceMustAllBe(1)), _console, new Turn(new Dice(5, numberGenerator), _console)),
                new Category(new Rule("Twos", DiceMustAllBe(2)), _console, new Turn(new Dice(5, numberGenerator), _console)),
                new Category(new Rule("Threes", DiceMustAllBe(3)), _console, new Turn(new Dice(5, numberGenerator), _console))
            };

            var scoreCard = new ScoreCard(categories, _console);

            _game = new YahtzeeGame(scoreCard);
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
                _console.PrintLine("Dice: D1:1 D2:2 D3:3 D4:4 D5:5");
                _console.PrintLine("[1] Dice to re-run:");
                _console.PrintLine("Dice: D1:3 D2:1 D3:3 D4:2 D5:4");
                _console.PrintLine("[2] Dice to re-run:");
                _console.PrintLine("Dice: D1:3 D2:5 D3:3 D4:1 D5:2");
                _console.PrintLine("Category Threes score: 2");

                _console.PrintLine("Yahtzee score");
                _console.PrintLine("Ones: 4");
                _console.PrintLine("Twos: 4");
                _console.PrintLine("Threes: 2");
                _console.PrintLine("Final score: 10");
            });
        }

        private Func<int[], int> DiceMustAllBe(int n) =>
            dice => dice.Count(d => d == n); 
    }
}
