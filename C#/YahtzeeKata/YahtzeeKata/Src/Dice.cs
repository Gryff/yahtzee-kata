using System;

namespace YahtzeeKata
{
    public class Dice
    {
        private int _value;
        private readonly Random _numGenerator;

        public Dice() { }

        public Dice(Random numGenerator)
        {
            _numGenerator = numGenerator;
        }

        public virtual void Roll()
        {
            _value = _numGenerator.Next(1, 7);
        }

        public virtual int Value() => _value;
    }
}