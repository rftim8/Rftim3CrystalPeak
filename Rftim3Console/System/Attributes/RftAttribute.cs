using System.Reflection;

namespace Rftim3Console.System.Attributes
{
    public class RftAttribute
    {
        // An enumeration of animals. Start at 1 (0 = uninitialized).
        private enum Animal
        {
            // Pets.
            Dog = 1,
            Cat,
            Bird,
        }

        public RftAttribute()
        {
            AnimalTypeTestClass testClass = new();
            Type type = testClass.GetType();
            // Iterate through all the methods of the class.
            foreach (MethodInfo mInfo in type.GetMethods())
            {
                // Iterate through all the Attributes for each method.
                foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo))
                {
                    // Check for the AnimalType attribute.
                    if (attr.GetType() == typeof(AnimalTypeAttribute)) Console.WriteLine($"Method {mInfo.Name} has a pet {((AnimalTypeAttribute)attr).Pet} attribute.");
                }
            }
        }

        // A custom attribute to allow a target to have a pet.
        [AttributeUsage(AttributeTargets.All)]
        private class AnimalTypeAttribute(Animal pet) : Attribute
        {
            // Keep a variable internally ...
            private protected Animal thePet = pet;

            // .. and show a copy to the outside world.
            public Animal Pet
            {
                get => thePet;
                set => thePet = value;
            }
        }

        // A test class where each method has its own pet.
        private class AnimalTypeTestClass
        {
            [AnimalType(Animal.Dog)]
            public static void DogMethod() { }

            [AnimalType(Animal.Cat)]
            public static void CatMethod() { }

            [AnimalType(Animal.Bird)]
            public static void BirdMethod() { }
        }
    }
}
