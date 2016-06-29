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
        private Turn _turn;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();
            _title = "Ones";
            _turn = Substitute.For<Turn>();
            _category = new Category(_title, _console, _turn);
        }

        [Test]
        public void PrintItsTitle()
        {
            _category.Play();

            _console.Received().PrintLine($"Category: {_title}");
        }
    }
}
