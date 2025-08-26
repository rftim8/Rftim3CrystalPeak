namespace Rftim3Console.System.Exceptions
{
    public class RftAccessViolationException
    {
        /// <summary>
        /// An access violation occurs in unmanaged or unsafe code when the code attempts to read 
        /// or write to memory that has not been allocated, or to which it does not have access
        /// </summary>
        public RftAccessViolationException()
        {
            throw new AccessViolationException();
        }
    }
}
