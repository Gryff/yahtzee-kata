using NSubstitute;
using NUnit.Framework;

namespace YahtzeeKata.Tests
{
    [TestFixture]
    class CategoryShould
    {
        [Test]
        public void PrintItsTitle()
        {
            var console = Substitute.For<IConsole>();
            var category = new Category("Ones", console);

            category.Play();

            console.Received().PrintLine("Category: Ones");
        }
    }
}
