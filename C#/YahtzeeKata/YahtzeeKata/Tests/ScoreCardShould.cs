using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class ScoreCardShould
    {
        [Test]
        public void PlayTheNextCategory()
        {
            var category = Substitute.For<Category>(null, null, null);

            var scoreCard = new ScoreCard(new List<Category> {category});

            scoreCard.PlayCategories();

            category.Received().Play();
        }
    }
}
