using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class YahtzeeFeature
    {
        [Test]
        public void Play_three_rounds_and_print_final_score()
        {
            var console = Substitute.For<IConsole>();
            var game = new YahtzeeGame(
                Enumerable.Repeat(
                    new Category(
                        "", new OnesRule(), new Turn(), new Dice()), 
                    3).ToList(),
                console);

            game.Play();

            Received.InOrder(() =>
            {
                console.PrintLine("Category: Ones");
                console.PrintLine("Dice: D1:2 D2:4 D3:1 D4:6 D5:1");
                console.PrintLine("[1] Dice to re-run:");
                //console.PrintLine("D1 D2 D4");
                console.PrintLine("Dice: D1:1 D2:5 D3:1 D4:2 D5:1");
                console.PrintLine("[2] Dice to re-run:");
                //console.PrintLine("D2 D4");
                console.PrintLine("Dice: D1:1 D2:1 D3:1 D4:5 D5:1");
                console.PrintLine("Category Ones score: 4");

                console.PrintLine("Category: Twos");
                console.PrintLine("Dice: D1:2 D2:4 D3:1 D4:6 D5:1");
                console.PrintLine("[1] Dice to re-run:");
                //console.PrintLine("D2 D3 D4 D5");
                console.PrintLine("Dice: D1:2 D2:5 D3:1 D4:2 D5:1");
                console.PrintLine("[2] Dice to re-run:");
                //console.PrintLine("D2 D3 D5");
                console.PrintLine("Dice: D1:2 D2:1 D3:1 D4:2 D5:1");
                console.PrintLine("Category Twos score: 2");

                console.PrintLine("Category: Threes");
                console.PrintLine("Dice: D1:2 D2:4 D3:1 D4:6 D5:1");
                console.PrintLine("[1] Dice to re-run:");
                //console.PrintLine("D1 D2 D3 D4 D5");
                console.PrintLine("Dice: D1:1 D2:5 D3:1 D4:2 D5:1");
                console.PrintLine("[2] Dice to re-run: ");
                //console.PrintLine("D1 D2 D3 D4 D5");
                console.PrintLine("Dice: D1:1 D2:1 D3:1 D4:5 D5:1");
                console.PrintLine("Category Threes score: 0");

                console.PrintLine("Yahtzee score");
                console.PrintLine("Ones: 4");
                console.PrintLine("Twos: 2");
                console.PrintLine("Threes: 0");
                console.PrintLine("Final score: 6");
            });
        }
    }
}
