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
            var categories = new Categories();
            var console = Substitute.For<IConsole>();
            var game = new YahtzeeGame(categories);

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
