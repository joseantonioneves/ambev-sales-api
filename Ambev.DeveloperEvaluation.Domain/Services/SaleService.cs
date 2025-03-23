using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public class SaleService : ISaleService
    {
        public void ApplyDiscounts(Sale sale)
        {
            foreach (var item in sale.Products)
            {
                if (item.Quantity > 20)
                {
                    throw new DomainException("Não é possível vender mais de 20 itens do mesmo produto.");
                }

                if (item.Quantity >= 10 && item.Quantity <= 20)
                {
                    item.Discount = 0.20m; // 20% de desconto
                }
                else if (item.Quantity >= 4 && item.Quantity < 10)
                {
                    item.Discount = 0.10m; // 10% de desconto
                }
                else
                {
                    item.Discount = 0; // Sem desconto
                }
            }
        }

        public void ValidateSale(Sale sale)
        {
            if (sale.Products == null || sale.Products.Count == 0)
            {
                throw new DomainException("A venda deve conter pelo menos um produto.");
            }

            foreach (var item in sale.Products)
            {
                if (item.Quantity <= 0)
                {
                    throw new DomainException("A quantidade do produto deve ser maior que zero.");
                }

                if (item.UnitPrice <= 0)
                {
                    throw new DomainException("O preço unitário do produto deve ser maior que zero.");
                }
            }
        }
    }
}