using CoreLibrary.Models;
using System.Collections.Generic;

namespace CoreLibrary.ServerModels
{
    public class Responce
    {
        public string Date { get; set; }
        public string PreviousDate { get; set; }
        public string PreviousURL { get; set; }
        public string Timestamp { get; set; }
        public Valutes Valute { get; set; }
        public List<Error> Errors { get; set; }
    }
}
