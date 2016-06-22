using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    class YahtzeeFeature
    {
        [Test]
        public void PlayThreeRounds()
        {
            var console = Substitute.For<IConsole>();
            var categories = new List<Category>
            {
                new Category("Ones", console)
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
