using System;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class DieShould
    {
        [Test]
        public void RollARandomNumber()
        {
            var dice = new Die(
                new Random(DateTime.Now.Millisecond));

            for (var i = 0; i < 10; i++)
            {
                dice.Roll();
                Assert.That(dice.Value(), Is.InRange(1, 6));
            }
        }
    }
}
