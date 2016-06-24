using System.Collections.Generic;
using System.Linq;

namespace YahtzeeKata
{
    public class Category
    {
        private readonly IConsole _console;
        private readonly IEnumerable<Dice> _die;
        private readonly string _title;

        public Category() { }

        public Category(string title, IConsole console, IEnumerable<Dice> die)
        {
            this._title = title;
            this._console = console;
            _die = die;
        }

        public virtual void Play()
        {
            _console.PrintLine($"Category: {_title}");

            PlayTurn();
        }

        private void PlayTurn()
        {
            _die.ToList().ForEach(d => d.Roll());
            
            PrintDie();
        }

        private void PrintDie()
        {
            var diceCount = 0;

            var dieValues = string.Join(
                " ",
                _die.Select(d => $"D{++diceCount}:{d.Value()}"));

            _console.PrintLine($"Dice: {dieValues}");
        }
    }
}