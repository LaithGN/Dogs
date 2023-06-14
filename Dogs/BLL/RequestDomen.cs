using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Dogs
{
    public class RequestDomen
    {
        public string Requests(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://whois.ru/" + url);

            var response = (HttpWebResponse)request.GetResponse();

            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}
