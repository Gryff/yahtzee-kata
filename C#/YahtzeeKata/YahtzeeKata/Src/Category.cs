namespace YahtzeeKata
{
    public class Category
    {
        private readonly IConsole _console;
        private readonly string _title;
        private readonly Turn _turn;

        public Category(string title, IConsole console, Turn turn)
        {
            _title = title;
            _console = console;
            _turn = turn;
        }

        public virtual void Play()
        {
            _console.PrintLine($"Category: {_title}");

            _turn.PlayFirstTurn();
            _turn.PlayAnotherTurn();
            _turn.PlayAnotherTurn();
        }
    }
}