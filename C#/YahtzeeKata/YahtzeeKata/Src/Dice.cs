using System;

namespace YahtzeeKata
{
    public class Dice
    {
        private int _value;

        public virtual void Roll()
        {
            _value = new Random(DateTime.Now.Millisecond).Next(1, 7);
        }

        public virtual int Value() => _value;
    }
}