namespace Rftim3LeetCode.Temp
{
    public class _01603_DesignParkingSystem
    {
        /// <summary>
        /// Design a parking system for a parking lot. The parking lot has three kinds of parking spaces: big, medium, and small, with a fixed number of slots for each size.
        /// Implement the ParkingSystem class:
        /// ParkingSystem(int big, int medium, int small) Initializes object of the ParkingSystem class.
        /// The number of slots for each parking space are given as part of the constructor.
        /// bool addCar(int carType) Checks whether there is a parking space of carType for the car that wants to get into the parking lot. 
        /// carType can be of three kinds: big, medium, or small, which are represented by 1, 2, and 3 respectively.
        /// A car can only park in a parking space of its carType. If there is no space available, return false, else park the car in that size space and return true.
        /// </summary>
        public _01603_DesignParkingSystem()
        {
            ParkingSystem obj = new(1, 1, 0);
            bool param_1 = obj.AddCar(1);
            bool param_2 = obj.AddCar(2);
            bool param_3 = obj.AddCar(3);
            bool param_4 = obj.AddCar(1);

            Console.WriteLine(param_1);
            Console.WriteLine(param_2);
            Console.WriteLine(param_3);
            Console.WriteLine(param_4);
        }

        public class ParkingSystem(int big, int medium, int small)
        {
            public int big = big, medium = medium, small = small;

            public bool AddCar(int carType)
            {
                switch (carType)
                {
                    case 1:
                        if (big > 0)
                        {
                            big--;
                            return true;
                        }
                        else return false;
                    case 2:
                        if (medium > 0)
                        {
                            medium--;
                            return true;
                        }
                        else return false;
                    case 3:
                        if (small > 0)
                        {
                            small--;
                            return true;
                        }
                        else return false;
                    default:
                        break;
                }

                return false;
            }
        }
    }
}
