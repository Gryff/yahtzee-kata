using System.Collections.Generic;
using System.Linq;
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
            _die = Enumerable.Repeat(Substitute.For<Dice>(), 5).ToList();

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
            
            _die.ForEach(d => d.Received().Roll());
        }

        [Test]
        public void PrintItsDie()
        {
            _die[0].Value().Returns(5);

            _category.Play();

            _console.Received().PrintLine("Dice: D1:5 D2:5 D3:5 D4:5 D5:5");
        }
    }
}
