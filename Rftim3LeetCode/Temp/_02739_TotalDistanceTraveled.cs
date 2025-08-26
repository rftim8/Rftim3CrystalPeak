namespace Rftim3LeetCode.Temp
{
    public class _02739_TotalDistanceTraveled
    {
        /// <summary>
        /// A truck has two fuel tanks. You are given two integers, mainTank representing the fuel present in the main tank in liters and 
        /// additionalTank representing the fuel present in the additional tank in liters.
        /// The truck has a mileage of 10 km per liter.
        /// Whenever 5 liters of fuel get used up in the main tank, if the additional tank has at least 1 liters of fuel, 
        /// 1 liters of fuel will be transferred from the additional tank to the main tank.
        /// Return the maximum distance which can be traveled.
        /// Note: Injection from the additional tank is not continuous. 
        /// It happens suddenly and immediately for every 5 liters consumed.
        /// </summary>
        public _02739_TotalDistanceTraveled()
        {
            Console.WriteLine(DistanceTraveled(5, 10));
            Console.WriteLine(DistanceTraveled(1, 2));
        }

        private static int DistanceTraveled(int mainTank, int additionalTank)
        {
            int d = 0;
            while (mainTank >= 5 && additionalTank > 0)
            {
                d += 50;
                mainTank -= 5;
                mainTank++;
                additionalTank--;
            }

            while (mainTank > 0)
            {
                d += 10;
                mainTank--;
            }

            return d;
        }
    }
}
