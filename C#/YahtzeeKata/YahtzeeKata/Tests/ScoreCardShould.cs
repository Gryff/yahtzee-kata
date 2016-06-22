using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    class ScoreCardShould
    {
        [Test]
        public void PlayTheNextCategory()
        {
            var category = Substitute.For<Category>();

            var scoreCard = new ScoreCard(new List<Category> {category});

            scoreCard.PlayNextCategory();

            category.Received().Play();
        }
    }
}
