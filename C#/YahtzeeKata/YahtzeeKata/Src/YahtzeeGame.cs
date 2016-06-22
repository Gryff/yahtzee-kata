using YahtzeeKata.Tests;

namespace YahtzeeKata
{
    public class YahtzeeGame
    {
        private ScoreCard _scoreCard;

        public YahtzeeGame(ScoreCard scoreCard)
        {
            this._scoreCard = scoreCard;
        }

        public void Run()
        {
            _scoreCard.PlayNextCategory();
        }
    }
}