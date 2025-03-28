using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem{
        public Guid Id { get; set; }
        public Guid SaleId { get; set; } // propriedade para a chave estrangeira
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal ItemTotal => Quantity * UnitPrice * (1 - Discount);
    }
    public class Sale
    {
        public Guid Id { get; set; }
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Branch { get; set; } = string.Empty;
        public List<SaleItem> Products { get; set; } = new List<SaleItem>();
    }
}