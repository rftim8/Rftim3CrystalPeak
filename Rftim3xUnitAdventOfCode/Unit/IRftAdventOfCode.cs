namespace Rftim3CP.AdventOfCode
{
    internal interface IRftAdventOfCode<T0, T1, T2>
    {
        static abstract T0? Input { get; }

        static abstract T1 Actual1(T0 input);

        static abstract T2 Actual2(T0 input);
    }
}
