using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class YahtzeeGameShould
    {
        [Test]
        public void RunTheGame()
        {
            var scoreCard = Substitute.For<ScoreCard>(new List<Category>());
            var game = new YahtzeeGame(scoreCard);

            game.Run();

            scoreCard.Received().PlayCategories();
        }
    }
}
