using System.Collections.Generic;

namespace CoreLibrary.Models
{
    public class Request
    {
        public List<ValuteEnum> Valutes { get; set; }
        public List<CryptsEnum> Crypts { get; set; }
        public Credentials Credentials { get; set; }
        public string Text { get; set; }
    }
}
