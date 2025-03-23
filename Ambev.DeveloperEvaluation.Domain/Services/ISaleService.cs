using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services
{
    public interface ISaleService
    {
        void ApplyDiscounts(Sale sale);
        void ValidateSale(Sale sale);
    }
}