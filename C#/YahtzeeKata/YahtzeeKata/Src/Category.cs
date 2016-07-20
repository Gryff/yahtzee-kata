namespace YahtzeeKata
{
    public class Category
    {
        private readonly IRule _rule;
        private readonly Turn _turn;
        private readonly Dice _dice;

        public virtual string Title { get; }

        public Category(string title, IRule rule, Turn turn, Dice dice)
        {
            Title = title;
            _rule = rule;
            _turn = turn;
            _dice = dice;
        }

        public virtual void Play()
        {
            _turn.Play();
            _turn.Play();
            _turn.Play();
        }

        public virtual int Score() => _rule.ScoreFor(_dice.GetDice());
    }
}