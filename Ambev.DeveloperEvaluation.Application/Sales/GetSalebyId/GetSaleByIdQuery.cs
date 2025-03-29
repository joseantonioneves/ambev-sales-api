using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    public class GetSaleByIdQuery : IRequest<SaleDetailDto>
    {
        public Guid Id { get; set; }
    }
}