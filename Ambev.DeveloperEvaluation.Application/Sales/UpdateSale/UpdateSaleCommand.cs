using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Sale? UpdatedSale { get; set; }
    }
}