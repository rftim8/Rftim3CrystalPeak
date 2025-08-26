namespace Rftim3LeetCode.Temp
{
    public class _02525_CategorizeBoxAccordingToCriteria
    {
        /// <summary>
        /// Given four integers length, width, height, and mass, representing the dimensions and mass of a box, respectively, return a string representing the category of the box.
        /// The box is "Bulky" if:
        /// Any of the dimensions of the box is greater or equal to 104.
        /// Or, the volume of the box is greater or equal to 109.
        /// If the mass of the box is greater or equal to 100, it is "Heavy".
        /// If the box is both "Bulky" and "Heavy", then its category is "Both".
        /// If the box is neither "Bulky" nor "Heavy", then its category is "Neither".
        /// If the box is "Bulky" but not "Heavy", then its category is "Bulky".
        /// If the box is "Heavy" but not "Bulky", then its category is "Heavy".
        /// Note that the volume of the box is the product of its length, width and height.
        /// </summary>
        public _02525_CategorizeBoxAccordingToCriteria()
        {
            Console.WriteLine(CategorizeBox(1000, 35, 700, 300));
            Console.WriteLine(CategorizeBox(200, 50, 800, 50));
        }

        private static string CategorizeBox(int length, int width, int height, int mass)
        {
            bool bulky = false;
            bool heavy = false;

            if (length >= 10000 || width >= 10000 || height >= 10000 || mass >= 10000 ||
                (long)(length * width * height) >= 1000000000) bulky = true;
            if (mass >= 100) heavy = true;

            if (bulky && heavy) return "Both";
            if (!bulky && !heavy) return "Neither";
            if (bulky && !heavy) return "Bulky";
            if (!bulky && heavy) return "Heavy";

            return "";
        }
    }
}
