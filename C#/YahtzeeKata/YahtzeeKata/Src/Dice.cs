using System;
using System.Linq;

namespace YahtzeeKata
{
    public class Dice
    {
        private readonly int[] _dice;
        private readonly Random _numberGenerator;

        public Dice() { }

        public Dice(int amount, Random numberGenerator)
        {
            _numberGenerator = numberGenerator;
            _dice = new int[amount];
        }

        public virtual void RollDice()
        {
            for (var i = 0; i < _dice.Length; i++)
            {
                _dice[i] = _numberGenerator.Next(1, 7);
            }
        }

        public virtual string DiceValues()
        {
            var diceCount = 0;
            
            var dieValues = string.Join(
                " ",
                _dice.Select(d => $"D{++diceCount}:{d}"));

            return dieValues;
        }
    }
}