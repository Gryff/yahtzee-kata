using System.Linq;

namespace YahtzeeKata
{
    public class Turn
    {
        private readonly Dice _dice;
        private readonly IConsole _console;
        private int _retryCount;

        public Turn(Dice dice, IConsole console)
        {
            _dice = dice;
            _console = console;
        }

        public virtual void PlayFirstTurn()
        {
            _dice.RollDice();

            PrintDice();
        }

        public virtual void PlayAnotherTurn()
        {
            _console.PrintLine($"[{++_retryCount}] Dice to re-run:");
            var userInput = _console.ReadLine();

            var diceToReRun = userInput
                .Replace("D", "")
                .Split()
                .Select(int.Parse)
                .ToArray();

            _dice.RollDice(diceToReRun);

            PrintDice();
        }

        private void PrintDice() => 
            _console.PrintLine($"Dice: {_dice.DiceValues()}");

        public virtual int[] GetDice()
        {
            return _dice.GetDice();
        }
    }
}