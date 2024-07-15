using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos.Lines
{
    public class LineDto
    {
        public int Ligne { get; set; }
        public string CodeArticle { get; set; }
        public string Description { get; set; }
        public string Entrepot { get; set; }
        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }
        public string Tarification { get; set; }
        public decimal MontantHT { get; set; }
    }
}
