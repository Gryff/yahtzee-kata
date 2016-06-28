using System;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class CategoryShould
    {
        private IConsole _console;
        private Category _category;
        private string _title;
        private Dice _dice;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();
            _title = "Ones";
            _dice = Substitute.For<Dice>();

            _category = new Category(_title, _console, _dice);
        }

        [Test]
        public void PrintItsTitle()
        {
            _category.Play();

            _console.Received().PrintLine($"Category: {_title}");
        }

        [Test]
        public void RollTheDice()
        {
            _category.Play();
            
            _dice.Received().RollDice();
        }

        [Test]
        public void PrintTheDice()
        {
            _dice.DiceValues().Returns("D1:5 D2:5 D3:5 D4:5 D5:5");

            _category.Play();

            _console.Received().PrintLine("Dice: D1:5 D2:5 D3:5 D4:5 D5:5");
        }

        [Test]
        public void PlayAnotherTurn()
        {
            _dice.DiceValues().Returns(
                "D1:1 D2:1 D3:5 D4:5 D5:5",
                "D1:1 D2:1 D3:1 D4:5 D5:5");

            _category.Play();
            
            Received.InOrder(() =>
            {
                _console.PrintLine("Category: Ones");
                _dice.RollDice();
                _console.PrintLine("Dice: D1:1 D2:1 D3:5 D4:5 D5:5");
                _console.PrintLine("[1] Die to re-run:");
                _console.ReadLine();
                _dice.RollDice(3, 4, 5);
                _console.PrintLine("Dice: D1:1 D2:1 D3:1 D4:5 D5:5");
            });
        }
    }
}
