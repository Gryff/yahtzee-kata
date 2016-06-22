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
            var categories = Substitute.For<Categories>();
            var game = new YahtzeeGame(categories);

            game.Run();

            categories.Received().PlayNextCategory();
        }
    }
}
