namespace YahtzeeKata
{
    public class YahtzeeGame
    {
        private readonly ScoreCard _scoreCard;

        public YahtzeeGame(ScoreCard scoreCard)
        {
            _scoreCard = scoreCard;
        }

        public void Run()
        {
            _scoreCard.PlayCategories();
            _scoreCard.PrintScore();
        }
    }
}