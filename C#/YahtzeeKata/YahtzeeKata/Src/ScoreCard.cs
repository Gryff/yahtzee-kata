using System.Collections.Generic;
using System.Linq;

namespace YahtzeeKata
{
    public class ScoreCard
    {
        private readonly List<Category> _categories;
        private readonly IConsole _console;

        public ScoreCard(List<Category> categories, IConsole console)
        {
            _console = console;
            _categories = categories;
        }

        public virtual void PlayCategories()
        {
            _categories.ForEach(c => c.Play());
        }

        public virtual void PrintScore()
        {
            _console.PrintLine("Yahtzee score");
            PrintCategoryScores();
            PrintFinalScore();
        }

        private void PrintCategoryScores()
        {
            _categories.ForEach(
                c => _console.PrintLine(c.FormatScore()));
        }

        private void PrintFinalScore()
        {
            var score = _categories.Sum(c => c.GetScore());

            _console.PrintLine($"Final score: {score}");
        }
    }
}