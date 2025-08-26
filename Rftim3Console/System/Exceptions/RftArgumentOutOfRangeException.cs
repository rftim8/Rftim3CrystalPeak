namespace Rftim3Console.System.Exceptions
{
    public class RftArgumentOutOfRangeException
    {
        public RftArgumentOutOfRangeException()
        {
            try
            {
                Guest guest1 = new("Ben", "Miller", 17);
                Console.WriteLine(guest1.GuestInfo);
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                Console.WriteLine($"Error: {argumentOutOfRangeException.Message}");
            }
        }

        private class Guest
        {
            private const int minimumRequiredAge = 21;

            private readonly string firstName;
            private readonly string lastName;
            private readonly int age;

            public Guest(string firstName, string lastName, int age)
            {
                if (age < minimumRequiredAge) throw new ArgumentOutOfRangeException(nameof(age), $"All guests must be {minimumRequiredAge}-years-old or older.");

                this.firstName = firstName;
                this.lastName = lastName;
                this.age = age;
            }

            public string? GuestInfo => $"{firstName} {lastName}, {age}";
        }
    }
}
