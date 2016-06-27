using System.Collections.Generic;
using System.Linq;

namespace YahtzeeKata
{
    public class Dice
    {
        private readonly List<Die> _dice;

        public Dice() { }

        public Dice(int count)
        {
            this._dice = Enumerable.Repeat(new Die(), count).ToList();
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