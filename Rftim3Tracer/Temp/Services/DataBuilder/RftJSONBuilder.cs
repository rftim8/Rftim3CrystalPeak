namespace Rftim3Tracer.Temp.Services.DataBuilder
{
    public class RftJSONBuilder
    {
        public static void RftReadDataFromFile()
        {
            //string? rftReadDataFromFile = File.ReadAllText(RftResources._12_JSAbacusFrameworkIO);
            //SalesTotal? rftSalesData = JsonConvert.DeserializeObject<SalesTotal>(rftReadDataFromFile);

            //if (rftSalesData is not null) Console.WriteLine($"{rftSalesData.Total}");
            //else Console.WriteLine($"No data found!");
        }

        class SalesTotal
        {
            public double Total { get; set; }
        }
    }
}
