using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    public class GetSaleByIdHandler : IRequestHandler<GetSaleByIdQuery, SaleDetailDto>
    {
        private readonly ISaleRepository _saleRepository;

        public GetSaleByIdHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<SaleDetailDto> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.Id);
            
            if (sale == null)
                return new SaleDetailDto();

            return new SaleDetailDto
            {
                Id = sale.Id,
                SaleNumber = sale.SaleNumber,
                SaleDate = sale.SaleDate,
                Customer = sale.Customer,
                TotalAmount = sale.TotalAmount,
                Branch = sale.Branch,
                IsCancelled = sale.IsCancelled,
                Products = sale.Products.Select(p => new SaleItemDto
                {
                    Product = p.Product,
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice,
                    Discount = p.Discount,
                    ItemTotal = p.ItemTotal
                }).ToList()
            };
        }
    }
}