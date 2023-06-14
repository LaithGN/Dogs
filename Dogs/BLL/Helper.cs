using Spire.Doc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Dogs
{
    public class Helper
    {
        public void Writer(string text)
        {
            using (StreamWriter sw = new StreamWriter("text.html", false, Encoding.UTF8))
            {
                sw.Write(text);
            }
            converter();
        }

        public bool Reader(DateTime date)
        {
            using (StreamReader reader = new StreamReader("test.xml",Encoding.UTF8,true))
            {
                XElement element = XElement.Load(reader);
                var el = element.XPathSelectElement("//item[11]/items[1]/item[3]");
                if (el == null)
                    el = element.XPathSelectElement("//item[12]/items[1]/item[3]");
                var searchDate = SearchDate(el.Value);
                if (searchDate > date)
                    return true;
                return false;
            }
        }
        DateTime SearchDate(string text)
        {
            string[] strings = text.Split(new string[] { "paid-till:", "free-date:" },StringSplitOptions.RemoveEmptyEntries);
            if (strings.Length < 2 )
                strings = text.Split(new string[] { "Registry Expiry Date:", "Registrar:" }, StringSplitOptions.RemoveEmptyEntries);
            var dateRaw = strings[1].Split(@"\");
            return Convert.ToDateTime(dateRaw[0]);
        }
        public void converter()
        {
            Document doc = new Document();
            doc.LoadFromFile("text.html");
            doc.SaveToFile("test.xml", FileFormat.Xml);
        }
    }
}
