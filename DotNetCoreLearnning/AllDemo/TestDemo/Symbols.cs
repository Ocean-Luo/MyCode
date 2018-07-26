using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo
{
    public class SymbolsInfo
    {
        public SymbolsInfo()
        {
            symbols = new List<symbols>();
        }
        public string timezone { get; set; }
        public string serverTime { get; set; }
        
        public List<symbols> symbols { get; set; }
    }

   

    public class symbols
    {
        public string symbol { get; set; }
        public string status { get; set; }
        public string baseAsset { get; set; }
        public string baseAssetPrecision { get; set; }
        public string quoteAsset { get; set; }

        public string quotePrecision { get; set; }
        public List<string> orderTypes { get; set; }
        public bool icebergAllowed { get; set; }
       

    }

   
}
