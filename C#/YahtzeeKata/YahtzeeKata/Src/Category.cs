using System.Collections.Generic;

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
            foreach (var dice in _die)
            {
                dice.Roll();
            }
        }
    }
}