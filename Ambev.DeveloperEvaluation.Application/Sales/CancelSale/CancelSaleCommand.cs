using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}