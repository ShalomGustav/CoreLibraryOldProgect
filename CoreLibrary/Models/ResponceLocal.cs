using System.Collections.Generic;
namespace CoreLibrary.Models
{
    public class ResponceLocal
    {
        public string Data { get; set; }
        public List<ValutesLocal> Valutesloc { get; set; }
        public List<ValutesLocal> ValutesEthloc { get; set; }
        public List<ValutesLocal> Valutes { get; set; }
        public List<ValutesLocal> Valute { get; set; }
        public List<Error> Errors { get; set; }
    }
}
