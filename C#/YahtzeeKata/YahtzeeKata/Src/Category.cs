namespace YahtzeeKata
{
    public class Category
    {
        private readonly IConsole _console;
        private readonly string _title;

        public Category() { }

        public Category(string title, IConsole console)
        {
            this._title = title;
            this._console = console;
        }

        public virtual void Play()
        {
            _console.PrintLine($"Category: {_title}");
        }
    }
}