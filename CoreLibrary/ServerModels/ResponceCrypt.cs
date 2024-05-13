using CoreLibrary.Models;
using System.Collections.Generic;

namespace CoreLibrary.ServerModels
{
    public class ResponceCrypt
    {
        public ResponceTiker Ticker { get; set; }
        public double Timestamp { get; set; }
        public List<Error> Errors { get; set; }
    }
}
