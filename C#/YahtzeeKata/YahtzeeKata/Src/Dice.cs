using System;
using System.Collections.Generic;
using System.Linq;

namespace YahtzeeKata
{
    public class Dice
    {
        private readonly List<Die> _dice;

        public Dice() { }

        public Dice(int amount, Random numberGenerator)
        {
            this._dice = Enumerable.Repeat(
                new Die(numberGenerator), amount).ToList();
        }

        public virtual void RollDice()
        {
            _dice.ToList().ForEach(d => d.Roll());
        }

        public virtual string DieValues()
        {
            var diceCount = 0;

            var dieValues = string.Join(
                " ",
                _dice.Select(d => $"D{++diceCount}:{d.Value()}"));

            return dieValues;
        }
    }
}