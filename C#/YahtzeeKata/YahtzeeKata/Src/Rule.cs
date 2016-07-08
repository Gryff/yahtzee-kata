using System;

namespace YahtzeeKata
{
    public class Rule
    {
        public virtual string Name { get; }
        private readonly Func<int[], int> _applyRule;

        public Rule(string name, Func<int[], int> applyRule)
        {
            _applyRule = applyRule;
            Name = name;
        }

        public virtual int Score(int[] dice) => _applyRule(dice);
    }
}
