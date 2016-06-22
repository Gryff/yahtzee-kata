using System.Collections.Generic;

namespace YahtzeeKata
{
    public class ScoreCard
    {
        private List<Category> categories;

        public ScoreCard() { }

        public ScoreCard(List<Category> categories)
        {
            this.categories = categories;
        }

        public virtual void PlayNextCategory()
        {
            throw new System.NotImplementedException();
        }
    }
}