using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace HttpWebRequestDemo
{
    public enum KLinePeriodType
    {
        //KLine_1Min = 1,
        //KLine_5Min = 2,
        //KLine_15Min = 3,
        //KLine_30Min = 4,
        //KLine_1H = 5,
        //KLine_4H = 6,
        //KLine_6H = 7,
        //KLine_12H = 8,
        //KLine_1D = 9,
        //KLine_1W = 10,
        //KLine_1M = 11,
        //KLine_1Y = 12
        KLine_1m,
        KLine_3m,
        KLine_5m,
        KLine_15m,
        KLine_30m,
        KLine_1h,
        KLine_2h,
        KLine_4h,
        KLine_6h,
        KLine_8h,
        KLine_12h,
        KLine_1d,
        KLine_3d,
        KLine_1w,
        KLine_1M
    }
    public class Kline
    {
        public string Symbol { get; set; }
        public string AssetSymbol { get; set; }
        public KLinePeriodType PeriodType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Size { get; set; }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            string htmlStr = string.Empty;

            string url = "https://www.binance.com/api/v1/klines?symbol=ETHBTC&limit=500&interval=1m&startTime=1498838400000&endTime=1498868400000";
            string s=GetJson(url);
            Uri uri = new Uri(url);
            string queryStr = uri.Query;
            queryStr = queryStr.TrimStart('?');
            List<string> lsQueryStr = queryStr.Split('&').ToList();
            List<string[]> ls=lsQueryStr.Select(x => x.Split('=')).ToList();
           


            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = 20000;
            string responseContent = string.Empty;

            try
            {
                using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (StreamReader ResponseStream = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        responseContent = ResponseStream.ReadToEnd();
                    }
                }
                
            }
            catch (WebException e)
            {
                //if(e.Status==WebExceptionStatus.)
                Console.WriteLine(e.Message);
            }
            

         
            //for (int i = 0; i < 100; i++)
            //{
            //    htmlStr = GetHtml(url);
            //    Console.WriteLine(i);
            //}

        }

        protected static  string GetJson(string url)
        {
            //访问https需加上这句话 
            // ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
            //访问http（不需要加上面那句话） 
            WebClient wc = new WebClient();
            wc.Credentials = CredentialCache.DefaultCredentials;
            wc.Encoding = Encoding.UTF8;
            string returnText = wc.DownloadString(url);

            if (returnText.Contains("errcode"))
            {
                //可能发生错误 
            }
            //Response.Write(returnText); 
            return returnText;
        }

        public static string GetHtml(string URI)
        {

            string fullhtml = null;

            while (true)
            {

                try
                {

                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URI);

                    req.Method = "GET";

                    req.UserAgent = "Opera/9.25 (Windows NT 6.0; U; en)";

                    req.KeepAlive = true; req.Timeout = 5000;

                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                    if (resp.StatusCode != HttpStatusCode.OK) //如果服务器未响应，那么继续等待相应

                        continue;

                    StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);

                    fullhtml = sr.ReadToEnd().Trim();

                    resp.Close();

                    sr.Close();

                    break;

                }

                catch (WebException e)
                {
                  
                    Console.WriteLine(e.Message);
                  
                    if (e.Message== "The operation has timed out.") continue;

                }

            }

            return fullhtml;

        }
    }
}
