using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Utilities
{
    public class ProdPrioritySession
    {
        public string Family { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public int Pallets { get; set; }
        public string SapOrder { get; set; }
        public int MinuteLoss { get; set; }
        public int PiecesLoss { get; set; }
        public string Geo { get; set; }
        public string Comments { get; set; }
        public string Toner { get; set; }
        public string PPVT { get; set; }
        public string Yeild { get; set; }
        public string Type { get; set; }
        public string Pages { get; set; }
        public string VKBPriority { get; set; }
        public int idLine { get; set; }
        public string idLocalizationMaterial { get; set; }
        public int Order { get; set; }
        public DateTime FilterDate { get; set; }
    }
}
