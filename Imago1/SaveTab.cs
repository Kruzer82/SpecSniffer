using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Sniffer
{
    public static class SaveTab
    {
        public static string SaleOrderId { get; set; }
        public static string Rep { get; set; } // Initials of person who installed PC
        public static string Comments { get; set; } //comments to SaleOrder
        public static string Licence { get; set; } //last picked licence
        //string where xml file is saved


        public static void ReadLastSettings()
        {
            try
            {
                XElement xElement = XElement.Load("Settings.xml");
                IEnumerable<XElement> settings = xElement.Elements("SaveTab");
                foreach (var x in settings)
                {
                    SaleOrderId = x.Attribute("SO").Value;
                    Rep = x.Attribute("RP").Value;
                    Comments = x.Attribute("Comments").Value;
                    Licence = x.Attribute("Licence").Value;
                }
            }
            catch
            {
                SaleOrderId = "n/a";
                Rep = "n/a";
                Comments = "";
                Licence = "No COA";
            }

        }

        public static void WriteSaveXML()
        {
            try
            {
                XDocument doc = XDocument.Load("Settings.xml");

                doc.Root.Element("SaveTab").ReplaceWith(new XElement("SaveTab",
                    new XAttribute("SO", SaleOrderId.Trim()),
                    new XAttribute("RP", Rep.Trim()),
                    new XAttribute("Comments", Comments.Trim()),
                    new XAttribute("Licence", Licence)
                    ));

                doc.Save("LastSettings.xml");
            }
            catch { }
        }
    }
}
