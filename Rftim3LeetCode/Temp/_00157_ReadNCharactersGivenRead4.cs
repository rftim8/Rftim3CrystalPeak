namespace Rftim3LeetCode.Temp
{
    public class _00157_ReadNCharactersGivenRead4
    {
        /// <summary>
        /// Given a file and assume that you can only read the file using a given method read4, implement a method to read n characters.
        /// 
        /// Method read4:
        /// 
        /// The API read4 reads four consecutive characters from file, then writes those characters into the buffer array buf4.
        /// 
        /// The return value is the number of actual characters read.
        /// 
        /// Note that read4() has its own file pointer, much like FILE* fp in C.
        /// 
        /// Definition of read4:
        /// 
        ///     Parameter:  char[] buf4
        ///     Returns:    int
        /// 
        /// buf4[] is a destination, not a source.The results from read4 will be copied to buf4[].
        /// Below is a high-level example of how read4 works:
        /// File file("abcde"); // File is "abcde", initially file pointer (fp) points to 'a'
        /// char[] buf4 = new char[4]; // Create buffer with enough space to store characters
        /// read4(buf4); // read4 returns 4. Now buf4 = "abcd", fp points to 'e'
        /// read4(buf4); // read4 returns 1. Now buf4 = "e", fp points to end of file
        /// read4(buf4); // read4 returns 0. Now buf4 = "", fp points to end of file
        /// 
        /// 
        /// Method read:
        /// 
        /// By using the read4 method, implement the method read that reads n characters from file and store it in the buffer array buf.
        /// Consider that you cannot manipulate file directly.
        /// 
        /// The return value is the number of actual characters read.
        /// 
        /// Definition of read:
        /// 
        ///     Parameters:	char[] buf, int n
        ///     Returns:	int
        /// 
        /// buf[] is a destination, not a source.You will need to write the results to buf[].
        /// Note:
        /// 
        /// Consider that you cannot manipulate the file directly. 
        /// The file is only accessible for read4 but not for read.
        /// The read function will only be called once for each test case.
        /// You may assume the destination buffer array, buf, is guaranteed to have enough space for storing n characters.
        /// </summary>
        public _00157_ReadNCharactersGivenRead4()
        {
            Console.WriteLine(ReadNCharactersGivenRead40([.. "abc"], 4));
            Console.WriteLine(ReadNCharactersGivenRead40([.. "abcde"], 5));
            Console.WriteLine(ReadNCharactersGivenRead40([.. "abcdABCD1234"], 12));
        }

        public static int ReadNCharactersGivenRead40(char[] a0, int a1) => RftReadNCharactersGivenRead40(a0, a1);

        private static List<char>? x;

        private static int RftReadNCharactersGivenRead40(char[] buf, int n)
        {
            x = [.. buf];
            int copiedChars = 0, readChars = 4;
            char[] buf4 = new char[4];

            while (copiedChars < n && readChars == 4)
            {
                readChars = Read4(buf4);

                for (int i = 0; i < readChars; ++i)
                {
                    if (copiedChars == n) return copiedChars;

                    buf[copiedChars] = buf4[i];
                    ++copiedChars;
                }
            }

            return copiedChars;
        }

        private static int Read4(char[] buf)
        {
            ArgumentNullException.ThrowIfNull(buf);

            if (x!.Count > 4)
            {
                x.RemoveRange(0, 4);
                return 4;
            }
            else return x.Count;
        }
    }
}
