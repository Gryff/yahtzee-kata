using System;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class DiceShould
    {
        private Random _numberGenerator;
        private Dice _dice;

        [SetUp]
        public void SetUp()
        {
            _numberGenerator = Substitute.For<Random>();
            _dice = new Dice(5, _numberGenerator);
        }

        [Test]
        public void ProduceDiceValues()
        {
            _numberGenerator.Next(1, 7).Returns(1, 2, 3, 4, 5);

            _dice.RollDice();

            Assert.That(_dice.DiceValues(), Is.EqualTo("D1:1 D2:2 D3:3 D4:4 D5:5"));
        }

        [Test]
        public void ReRollOnlySpecifiedDice()
        {
            _numberGenerator.Next(1, 7).Returns(4, 5, 6);

            _dice.RollDice(1, 2, 3);

            Assert.That(_dice.DiceValues(), Is.EqualTo("D1:4 D2:5 D3:6 D4:0 D5:0"));
        }
    }
}
