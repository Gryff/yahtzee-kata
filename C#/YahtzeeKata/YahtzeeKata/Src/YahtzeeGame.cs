using YahtzeeKata.Tests;

namespace YahtzeeKata
{
    public class YahtzeeGame
    {
        private Categories _categories;

        public YahtzeeGame(Categories categories)
        {
            this._categories = categories;
        }

        public void Run()
        {
            _categories.PlayNextCategory();
        }
    }
}