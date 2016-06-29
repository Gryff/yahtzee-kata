using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class TurnShould
    {
        private Turn _turn;
        private Dice _dice;
        private IConsole _console;

        [SetUp]
        public void SetUp()
        {
            _dice = Substitute.For<Dice>();
            _console = Substitute.For<IConsole>();
            _turn = new Turn(_dice, _console);
        }

        [Test]
        public void RollTheDice()
        {
            _turn.PlayTurn();

            _dice.Received().RollDice();
        }

        [Test]
        public void PrintTheDice()
        {
            _dice.DiceValues().Returns("D1:5 D2:5 D3:5 D4:5 D5:5");

            _turn.PlayTurn();

            _console.Received().PrintLine("Dice: D1:5 D2:5 D3:5 D4:5 D5:5");
        }
    }
}
