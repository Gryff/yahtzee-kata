using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    public class CategoryShould
    {
        private Turn _turn;
        private Category _category;
        private Dice _dice;
        private IRule _onesRule;

        [SetUp]
        public void SetUp()
        {
            _turn = Substitute.For<Turn>();
            _dice = Substitute.For<Dice>();
            _onesRule = Substitute.For<IRule>();
            _category = new Category("Ones", _onesRule, _turn, _dice);
        }

        [Test]
        public void Play_three_turns()
        {
            _category.Play();

            _turn.Received(3).Play();
        }

        [Test]
        public void Calculate_score()
        {
            var dice = new[] {1, 2, 3, 4, 5};
            _dice.GetDice().Returns(dice);
            _onesRule.ScoreFor(dice).Returns(1);

            _category.Play();

            Assert.That(_category.Score(), Is.EqualTo(1));
        }
    }
}
