using System;

namespace YahtzeeKata
{
    public class Category
    {
        private readonly IConsole _console;
        private readonly string _title;
        private readonly Func<int[], int> _score;
        private readonly Turn _turn;

        public Category(string title, Func<int[], int> score, IConsole console, Turn turn)
        {
            _score = score;
            _title = title;
            _console = console;
            _turn = turn;
        }

        public virtual void Play()
        {
            _console.PrintLine($"Category: {_title}");

            _turn.PlayFirstTurn();
            _turn.PlayAnotherTurn();
            _turn.PlayAnotherTurn();

            _console.PrintLine($"Category {_title} score: {Score()}");
        }

        private int Score() => _score(_turn.GetDice());
    }
}