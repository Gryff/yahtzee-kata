using System;

namespace YahtzeeKata
{
    public class Die
    {
        private int _value;
        private readonly Random _numGenerator;

        public Die() { }

        public Die(Random numGenerator)
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