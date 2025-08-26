namespace Rftim3LeetCode.Temp
{
    public class _01184_DistanceBetweenBusStops
    {
        /// <summary>
        /// A bus has n stops numbered from 0 to n - 1 that form a circle. We know the distance between all pairs 
        /// of neighboring stops where distance[i] is the distance between the stops number i and (i + 1) % n.
        /// The bus goes along both directions i.e.clockwise and counterclockwise.
        /// Return the shortest distance between the given start and destination stops.
        /// </summary>
        public _01184_DistanceBetweenBusStops()
        {
            Console.WriteLine(DistanceBetweenBusStops(
                [1, 2, 3, 4],
                0,
                1
            ));
            Console.WriteLine(DistanceBetweenBusStops(
                [1, 2, 3, 4],
                0,
                2
            ));
            Console.WriteLine(DistanceBetweenBusStops(
                [1, 2, 3, 4],
                0,
                3
            ));
            Console.WriteLine(DistanceBetweenBusStops(
                [7, 6, 3, 0, 3],
                0,
                4
            ));
            Console.WriteLine(DistanceBetweenBusStops(
                [7, 10, 1, 12, 11, 14, 5, 0],
                7,
                2
            ));
        }

        private static int DistanceBetweenBusStops(int[] distance, int start, int destination)
        {
            int c = start < destination ? distance[start..destination].Sum() : distance[destination..start].Sum();
            int d = distance.Sum() - c;

            return d > c ? c : d;
        }
    }
}
