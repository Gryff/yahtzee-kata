using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    class CategoryShould
    {
        private IConsole _console;
        private Category _category;
        private string _title;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();
            _title = "Ones";
            _category = new Category(_title, _console, new List<Dice>());
        }

        [Test]
        public void PrintItsTitle()
        {
            _category.Play();

            _console.Received().PrintLine($"Category: {_title}");
        }

        [Test]
        public void RollItsDie()
        {
            var dice = Substitute.For<Dice>();
            var die = new List<Dice> { dice };
            _category = new Category(_title, _console, die);

            _category.Play();
            
            dice.Received().Roll();
        }
    }
}
