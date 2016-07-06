using System.Collections.Generic;

namespace YahtzeeKata
{
    public class ScoreCard
    {
        private readonly List<Category> _categories;

        public ScoreCard(List<Category> categories)
        {
            _categories = categories;
        }

        public virtual void PlayCategories()
        {
            _categories.ForEach(c => c.Play());
        }
    }
}