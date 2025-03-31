namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; }= string.Empty;
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Branch { get; set; }= string.Empty;
        public List<SaleItem> Products { get; set; } = new List<SaleItem>();
        public bool IsCancelled { get; set; } = false; // Adicione esta linha
    }
}