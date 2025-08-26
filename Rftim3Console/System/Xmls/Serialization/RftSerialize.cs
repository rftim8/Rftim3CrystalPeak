using System.Globalization;
using System.Xml.Serialization;

namespace Rftim3Console.System.Xmls.Serialization
{
    public class RftSerialize
    {
        public RftSerialize()
        {
            Samples();
        }

        [Serializable]
        public struct DateWithTimeZone(DateTime dateValue, TimeZoneInfo timeZone)
        {
            private TimeZoneInfo tz = timeZone ?? TimeZoneInfo.Local;
            private DateTime dt = dateValue;

            public TimeZoneInfo TimeZone
            {
                readonly get { return tz; }
                set { tz = value; }
            }

            public DateTime DateTime
            {
                readonly get { return dt; }
                set { dt = value; }
            }
        }

        private static void Samples()
        {
            File.Delete(filenameTxt);
            PersistAsLocalStrings();

            //File.Delete(filenameTxt);
            //PersistAsInvariantStrings();

            File.Delete(filenameInts);
            PersistAsIntegers();

            File.Delete(filenameXml);
            PersistAsXML();
        }

        #region Sample0
        private const string filenameTxt = @"/RftCS/RftCS/RftCS/RftResources/BadDates.txt";

        private static void PersistAsLocalStrings()
        {
            SaveLocalDatesAsString();
            RestoreLocalDatesFromString();
        }

        private static void SaveLocalDatesAsString()
        {
            DateTime[] dates = [
                new(2014, 6, 14, 6, 32, 0),
                new(2014, 7, 10, 23, 49, 0),
                new(2015, 1, 10, 1, 16, 0),
                new(2014, 12, 20, 21, 45, 0),
                new(2014, 6, 2, 15, 14, 0)
            ];
            string? output = null;

            Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}");
            Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:");
            for (int ctr = 0; ctr < dates.Length; ctr++)
            {
                Console.WriteLine(dates[ctr].ToString("f"));
                output += dates[ctr].ToString() + (ctr != dates.Length - 1 ? "|" : "");
            }
            StreamWriter sw = new(filenameTxt);
            sw.Write(output);
            sw.Close();
            Console.WriteLine("Saved dates...");
        }

        private static void RestoreLocalDatesFromString()
        {
            TimeZoneInfo.ClearCachedData();
            Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            StreamReader sr = new(filenameTxt);
            string[] inputValues = sr.ReadToEnd().Split('\\', StringSplitOptions.RemoveEmptyEntries);
            sr.Close();
            Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system: ");
            foreach (string inputValue in inputValues)
            {
                if (DateTime.TryParse(inputValue, out DateTime dateValue)) Console.WriteLine($"'{inputValue}' --> {dateValue:f}");
                else Console.WriteLine($"Cannot parse '{inputValue}'");
            }
            Console.WriteLine("Restored dates...");
        }
        #endregion

        #region Sample1
        private static void PersistAsInvariantStrings()
        {
            SaveDatesAsInvariantStrings();
            RestoreDatesAsInvariantStrings();
        }

        private static void SaveDatesAsInvariantStrings()
        {
            DateTime[] dates = [
                new DateTime(2014, 6, 14, 6, 32, 0),
                new DateTime(2014, 7, 10, 23, 49, 0),
                new DateTime(2015, 1, 10, 1, 16, 0),
                new DateTime(2014, 12, 20, 21, 45, 0),
                new DateTime(2014, 6, 2, 15, 14, 0)
            ];
            string output = string.Empty;

            Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}");
            Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:");
            for (int ctr = 0; ctr < dates.Length; ctr++)
            {
                Console.WriteLine(dates[ctr].ToString("f"));
                output += $"{dates[ctr].ToUniversalTime().ToString("O", CultureInfo.InvariantCulture)} {(ctr != dates.Length - 1 ? "|" : "")}";
            }
            StreamWriter sw = new(filenameTxt);
            sw.Write(output);
            sw.Close();
            Console.WriteLine("Saved dates...");
        }

        private static void RestoreDatesAsInvariantStrings()
        {
            TimeZoneInfo.ClearCachedData();
            Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            StreamReader sr = new(filenameTxt);
            string[] inputValues = sr.ReadToEnd().Split('|', StringSplitOptions.RemoveEmptyEntries);
            sr.Close();
            Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system: ");
            foreach (string inputValue in inputValues)
            {
                if (DateTime.TryParseExact(inputValue, "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out DateTime dateValue))
                {
                    Console.WriteLine($"'{inputValue}' --> {dateValue.ToLocalTime():f}");
                }
                else Console.WriteLine($"Cannot parse {inputValue}");
            }
            Console.WriteLine("Restored dates...");
        }
        #endregion

        #region Sample2
        private const string filenameInts = @"/RftCS/RftCS/RftCS/RftResources/IntDates.bin";

        private static void PersistAsIntegers()
        {
            SaveDatesAsInts();
            RestoreDatesAsInts();
        }

        private static void SaveDatesAsInts()
        {
            DateTime[] dates = [
                new(2014, 6, 14, 6, 32, 0),
                new(2014, 7, 10, 23, 49, 0),
                new(2015, 1, 10, 1, 16, 0),
                new(2014, 12, 20, 21, 45, 0),
                new(2014, 6, 2, 15, 14, 0)
            ];

            Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}");
            Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:");
            long[] ticks = new long[dates.Length];
            for (int ctr = 0; ctr < dates.Length; ctr++)
            {
                Console.WriteLine(dates[ctr].ToString("f"));
                ticks[ctr] = dates[ctr].ToUniversalTime().Ticks;
            }
            FileStream fs = new(filenameInts, FileMode.Create);
            BinaryWriter bw = new(fs);
            bw.Write(ticks.Length);
            foreach (long tick in ticks)
            {
                bw.Write(tick);
            }

            bw.Close();
            Console.WriteLine("Saved dates...");
        }

        private static void RestoreDatesAsInts()
        {
            TimeZoneInfo.ClearCachedData();
            Console.WriteLine($"Current Time Zone: {TimeZoneInfo.Local.DisplayName}");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            FileStream fs = new(filenameInts, FileMode.Open);
            BinaryReader br = new(fs);
            int items;
            DateTime[] dates;

            try
            {
                items = br.ReadInt32();
                dates = new DateTime[items];

                for (int ctr = 0; ctr < items; ctr++)
                {
                    long ticks = br.ReadInt64();
                    dates[ctr] = new DateTime(ticks).ToLocalTime();
                }
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("File corruption detected. Unable to restore data...");
                return;
            }
            catch (IOException)
            {
                Console.WriteLine("Unspecified I/O error. Unable to restore data...");
                return;
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("File corruption detected. Unable to restore data...");
                return;
            }
            finally
            {
                br.Close();
            }

            Console.WriteLine($"The dates on an {Thread.CurrentThread.CurrentCulture.Name} system:");
            foreach (DateTime value in dates)
            {
                Console.WriteLine(value.ToString("f"));
            }

            Console.WriteLine("Restored dates...");
        }
        #endregion

        #region Sample3
        private const string filenameXml = @"/RftCS/RftCS/RftCS/RftResources/LeapYears.xml";

        private static void PersistAsXML()
        {
            List<DateTime> leapYears = [];
            for (int year = 2000; year <= 2100; year += 4)
            {
                if (DateTime.IsLeapYear(year)) leapYears.Add(new DateTime(year, 2, 29));
            }
            DateTime[] dateArray = [.. leapYears];

            XmlSerializer serializer = new(dateArray.GetType());
            TextWriter sw = new StreamWriter(filenameXml);

            try
            {
                serializer.Serialize(sw, dateArray);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sw?.Close();
            }

            DateTime[]? deserializedDates;
            using (FileStream? fs = new(filenameXml, FileMode.Open))
            {
                deserializedDates = serializer.Deserialize(fs) as DateTime[];
            }

            // Display the dates.
            Console.WriteLine($"Leap year days from 2000-2100 on an {Thread.CurrentThread.CurrentCulture.Name} system:");
            int nItems = 0;

            if (deserializedDates?.Length > 0)
            {
                foreach (DateTime dat in deserializedDates)
                {
                    Console.WriteLine($"   {dat:d}     ");
                    nItems++;
                    if (nItems % 5 == 0) Console.WriteLine();
                }
            }
        }
        #endregion
    }
}
