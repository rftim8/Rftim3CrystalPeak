namespace Rftim3Console.System.Actions
{
    public class RftAction
    {
        private delegate void ShowValue();

        public RftAction()
        {
            Name testName = new("Koani");
            ShowValue showMethod = testName.DisplayToConsole;
            showMethod();

            Action showMethod0 = testName.DisplayToConsole;
            showMethod0();

            #region Legacy
            //Action showMethod1 = delegate () { testName.DisplayToConsole(); };
            //showMethod1();

            //Action showMethod2 = () => testName.DisplayToConsole();
            //showMethod2();
            #endregion
        }

        private class Name(string name)
        {
            private readonly string instanceName = name;

            public void DisplayToConsole() => Console.WriteLine(instanceName);
        }
    }
}
