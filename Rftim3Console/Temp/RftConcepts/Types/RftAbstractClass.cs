namespace Rftim3Console.Temp.RftConcepts.Types
{
    public abstract class RftAbstract
    {
        public abstract int Evaluate(int x);
    }

    public class RftAbstractClass : RftAbstract
    {
        public RftAbstractClass()
        {
            Console.WriteLine(Evaluate(12));
        }

        public override int Evaluate(int x)
        {
            return 5;
        }
    }
}
