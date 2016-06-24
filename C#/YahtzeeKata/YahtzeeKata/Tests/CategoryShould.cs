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
        private List<Dice> _die;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();
            _title = "Ones";
            _die = new List<Dice> { Substitute.For<Dice>() };

            _category = new Category(_title, _console, _die);
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
            _category.Play();
            
            _die[0].Received().Roll();
        }

        [Test]
        public void PrintItsDie()
        {
            _die[0].Value().Returns(5);

            _category.Play();

            _console.Received().PrintLine("Dice: D1:5");
        }
    }
}
