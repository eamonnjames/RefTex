using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml;

namespace ABMXml
{
    class Program
    {
        static void Main(string[] args)
        {
            var codes = readXml();
        }
        private static List<string> readXml()
        {
            String XmlFile = @"ABM.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlFile);

            var ListOfCodes = new List<string>();

            var referenceList = doc.SelectNodes("//Reference");
            foreach (XmlNode a in referenceList)
            {
                if(a.Attributes["RefCode"].Value == "CAR" || a.Attributes["RefCode"].Value == "MWB" || a.Attributes["RefCode"].Value == "TRV")
                {
                    var refText = a.SelectNodes("RefText");

                    foreach(XmlNode x in refText)
                    {
                        ListOfCodes.Add(x.InnerText);
                    }

                }
            }
            return ListOfCodes;
        }
    }
}
