namespace YahtzeeKata
{
    public class Category
    {
        private readonly IConsole _console;
        private readonly string _title;
        private readonly Dice _dice;

        public Category() { }

        public Category(string title, IConsole console, Dice dice)
        {
            this._title = title;
            this._console = console;
            _dice = dice;
        }

        public virtual void Play()
        {
            _console.PrintLine($"Category: {_title}");

            PlayTurn();
        }

        private void PlayTurn()
        {
            _dice.RollDice();

            PrintDice();
        }

        private void PrintDice() => 
            _console.PrintLine($"Dice: {_dice.DiceValues()}");
    }
}