﻿using System.Collections.Generic;

namespace YahtzeeKata
{
    public class ScoreCard
    {
        private readonly List<Category> _categories;

        public ScoreCard() { }

        public ScoreCard(List<Category> categories)
        {
            this._categories = categories;
        }

        public virtual void PlayNextCategory()
        {
            foreach (var category in _categories)
            {
                category.Play();
            }
        }
    }
}