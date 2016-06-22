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
            var game = new YahtzeeGame();
            var console = Substitute.For<IConsole>();

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
