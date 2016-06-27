using System;

namespace YahtzeeKata
{
    public class Die
    {
        private int _value;
        private readonly Random _numberGenerator;

        public Die() { }

        public Die(Random numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }

        public virtual void Roll()
        {
            _value = _numberGenerator.Next(1, 7);
        }

        public virtual int Value() => _value;
    }
}