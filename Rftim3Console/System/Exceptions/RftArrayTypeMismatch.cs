namespace Rftim3Console.System.Exceptions
{
    public class RftArrayTypeMismatch
    {
        public RftArrayTypeMismatch()
        {
            string[] names = ["Dog", "Cat", "Fish"];
            object[] objs = names;

            try
            {
                objs[2] = "Mouse";

                foreach (object animalName in objs)
                {
                    Console.WriteLine(animalName);
                }
            }
            catch (ArrayTypeMismatchException)
            {
                // Not reached; "Mouse" is of the correct type.
                Console.WriteLine("Exception Thrown.");
            }

            try
            {
                object obj = 13;
                objs[2] = obj;
            }
            catch (ArrayTypeMismatchException)
            {
                // Always reached, 13 is not a string.
                Console.WriteLine("New element is not of the correct type.");
            }

            // Set objs to an array of objects instead of
            // an array of strings.
            objs = new object[3];
            try
            {
                objs[0] = "Turtle";
                objs[1] = 12;
                objs[2] = 2.341;

                foreach (object element in objs)
                {
                    Console.WriteLine(element);
                }
            }
            catch (ArrayTypeMismatchException)
            {
                // ArrayTypeMismatchException is not thrown this time.
                Console.WriteLine("Exception Thrown.");
            }
        }
    }
}
