using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Dogs
{
    public class RequestDomen
    {
        public string Requests(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://whois7.ru/" + url);
            request.Method = "GET";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";
            request.Timeout = 6000;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36 OPR/98.0.0.0 (Edition Yx GX)";
            var response = (HttpWebResponse)request.GetResponse();
            Thread.Sleep(1000);
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}
