namespace Rftim3Console.System.EventHandlers
{
    public class RftEventHandler
    {
        private int n;
        private readonly MyList<string> names;

        public RftEventHandler()
        {
            n = 0;
            names = new();
            Test();
            names.Add("werwerwt");
            names.Add("werwerwt");
            names.Add("werwerwt");
            names.Add("werwerwt");
            names.Add("werwerwt");

            Console.WriteLine(n);
            foreach (string item in names.L)
            {
                Console.WriteLine(item);
            }
        }

        private void Test()
        {
            names.Changed += ListChanged;
        }

        private void ListChanged(object? sender, EventArgs e)
        {
            n++;
        }

        class MyList<T>
        {
            public EventHandler? Changed;
            public List<T> L { get; set; } = [];

            public MyList()
            {

            }

            public void Add(T x)
            {
                L.Add(x);
                OnChanged();
            }

            protected virtual void OnChanged() => Changed?.Invoke(this, EventArgs.Empty);
        }
    }
}
