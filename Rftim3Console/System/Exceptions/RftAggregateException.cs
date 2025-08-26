namespace Rftim3Console.System.Exceptions
{
    public class RftAggregateException
    {
        public RftAggregateException()
        {
            Task x = RftTest();
            x.Start();
        }

        static async Task RftTest()
        {
            // Get a folder path whose directories should throw an UnauthorizedAccessException.
            string? path = $"{Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile))!.FullName}";
            await Console.Out.WriteLineAsync(path);

            // Use this line to throw UnauthorizedAccessException, which we handle.
            Task<string[]> task1 = Task<string[]>.Factory.StartNew(() => GetAllFiles(path));

            // Use this line to throw an exception that is not handled.
            // Task task1 = Task.Factory.StartNew(() => { throw new IndexOutOfRangeException(); } );
            try
            {
                await task1;

                foreach (string item in task1.Result)
                {
                    await Console.Out.WriteLineAsync(item);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Caught unauthorized access exception-await behavior");
            }
            catch (AggregateException ae)
            {
                Console.WriteLine("Caught aggregate exception-Task.Wait behavior");
                ae.Handle((x) =>
                {
                    if (x is UnauthorizedAccessException) // This we know how to handle.
                    {
                        Console.WriteLine("You do not have permission to access all folders in this path.");
                        Console.WriteLine("See your network administrator or try another path.");
                        return true;
                    }

                    return false; // Let anything else stop the application.
                });
            }

            Console.WriteLine("task1 Status: {0}{1}", task1.IsCompleted ? "Completed," : "", task1.Status);
        }

        static string[] GetAllFiles(string str)
        {
            // Should throw an UnauthorizedAccessException exception.
            return Directory.GetFiles(str, "*.txt", SearchOption.AllDirectories);
        }
    }
}
