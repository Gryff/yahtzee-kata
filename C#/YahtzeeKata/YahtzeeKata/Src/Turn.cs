namespace YahtzeeKata
{
    public class Turn
    {
        private readonly Dice _dice;
        private readonly IConsole _console;

        public Turn() { }

        public Turn(Dice dice, IConsole console)
        {
            _dice = dice;
            _console = console;
        }

        public virtual void PlayTurn()
        {
            _dice.RollDice();

            PrintDice();
        }

        private void PrintDice() => 
            _console.PrintLine($"Dice: {_dice.DiceValues()}");
    }
}