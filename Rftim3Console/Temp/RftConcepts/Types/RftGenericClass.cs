namespace Rftim3Console.Temp.RftConcepts.Types
{
    public class RftGenericClass<TFirst, TSecond>(TFirst? first, TSecond? second)
    {
        public TFirst? First { get; } = first;
        public TSecond? Second { get; } = second;
    }
}
