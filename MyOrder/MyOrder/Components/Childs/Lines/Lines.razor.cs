namespace MyOrder.Components.Childs.Lines
{
    public partial class Lines
    {
    }

    public class LineItem
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
