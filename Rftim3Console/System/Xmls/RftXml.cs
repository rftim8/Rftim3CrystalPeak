using System.Xml;

namespace Rftim3Console.System.Xmls
{
    public class RftXml
    {
        private static readonly string path = $"{Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.FullName}\\RftResources\\LeapYears.xml";

        public RftXml()
        {
            RftXmlRead(path);
        }

        private static void RftXmlRead(string path)
        {
            XmlTextReader xmlTextReader = new(path);

            try
            {
                while (xmlTextReader.Read())
                {
                    if (xmlTextReader.NodeType == XmlNodeType.Text) Console.WriteLine(xmlTextReader.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
