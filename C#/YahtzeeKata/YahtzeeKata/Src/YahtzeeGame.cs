using System.Collections.Generic;
using System.Linq;

namespace YahtzeeKata
{
    public class YahtzeeGame
    {
        private readonly List<Category> _categories;
        private readonly IConsole _console;

        public YahtzeeGame(List<Category> categories, IConsole console)
        {
            _categories = categories;
            _console = console;
        }

        public void Play()
        {
            _categories.ForEach(c => c.Play());

            PrintFinalScore();
        }

        private void PrintFinalScore()
        {
            _console.PrintLine("Yahtzee score");

            _categories.ForEach(
                c => _console.PrintLine($"{c.Title}: {c.Score()}"));

            _console.PrintLine(
                $"Final score: {_categories.Sum(c => c.Score())}");
        }
    }
}