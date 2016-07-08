using System;

namespace YahtzeeKata
{
    public class Category
    {
        private readonly Rule _rule;
        private readonly IConsole _console;
        private readonly Turn _turn;

        public Category(Rule rule, IConsole console, Turn turn)
        {
            _rule = rule;
            _console = console;
            _turn = turn;
        }

        public virtual void Play()
        {
            PrintTitle();

            _turn.PlayFirstTurn();
            _turn.PlayAnotherTurn();
            _turn.PlayAnotherTurn();

            PrintScore();
        }

        private void PrintTitle() => 
            _console.PrintLine($"Category: {_rule.Name}");

        private void PrintScore() => 
            _console.PrintLine($"Category {_rule.Name} score: {_rule.Score(_turn.GetDice())}");
    }
}