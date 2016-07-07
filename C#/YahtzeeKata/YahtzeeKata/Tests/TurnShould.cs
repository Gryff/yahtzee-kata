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
            _dice = Substitute.For<Dice>(0, null);
            _console = Substitute.For<IConsole>();
            _turn = new Turn(_dice, _console);
        }

        [Test]
        public void RollTheDice()
        {
            _turn.PlayFirstTurn();

            _dice.Received().RollDice();
        }

        [Test]
        public void PrintTheDice()
        {
            _dice.DiceValues().Returns("D1:5 D2:5 D3:5 D4:5 D5:5");

            _turn.PlayFirstTurn();

            _console.Received().PrintLine("Dice: D1:5 D2:5 D3:5 D4:5 D5:5");
        }

        [Test]
        public void OnSubsequentTurnsRollOnlySpecifiedDice()
        {
            _console.ReadLine().Returns("D1 D2 D3");

            _turn.PlayAnotherTurn();

            Received.InOrder(() =>
            {
                _console.PrintLine("[1] Dice to re-run:");
                _console.ReadLine();
                _dice.Received().RollDice(1, 2, 3);
            });
        }

        [Test]
        public void ShowTheRetryNumberOfTheTurn()
        {
            _console.ReadLine().Returns("D1");

            _turn.PlayAnotherTurn();
            _turn.PlayAnotherTurn();

            Received.InOrder(() =>
            {
                _console.PrintLine("[1] Dice to re-run:");
                _console.PrintLine("[2] Dice to re-run:");
            });
        }
    }
}
