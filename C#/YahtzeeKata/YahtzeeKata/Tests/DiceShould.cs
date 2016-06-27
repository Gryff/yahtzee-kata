using System;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    class DiceShould
    {
        [Test]
        public void ProduceDiceValues()
        {
            Random numberGenerator = Substitute.For<Random>();
            numberGenerator.Next(1, 7).Returns(1, 2, 3, 4, 5);

            var dice = new Dice(5, numberGenerator);

            dice.RollDice();

            Assert.That(dice.DiceValues(), Is.EqualTo("D1:1 D2:2 D3:3 D4:4 D5:5"));
        }
    }
}
