using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class YahtzeeFeature
    {
        [Test]
        public void PlayThreeRounds()
        {
            var console = Substitute.For<IConsole>();
            var die = Enumerable.Repeat(new Dice(), 5).ToList();

            var categories = new List<Category>
            {
                new Category("Ones", console, die),
                new Category("Twos", console, die),
                new Category("Threes", console, die)
            };

            var scoreCard = new ScoreCard(categories);
            var game = new YahtzeeGame(scoreCard);

            game.Run();

            Received.InOrder(() =>
            {
                console.PrintLine("Category: Ones");
                console.PrintLine("Category: Twos");
                console.PrintLine("Category: Threes");
            });
        }
    }
}
