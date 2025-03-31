using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public class GetSalesHandler : IRequestHandler<GetSalesQuery, IEnumerable<SaleDto>>
    {
        private readonly ISaleRepository _saleRepository;

        public GetSalesHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<IEnumerable<SaleDto>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
        {
            var sales = await _saleRepository.GetAllAsync();
            
            if (request.IsCancelled.HasValue)
            {
                sales = sales.Where(s => s.IsCancelled == request.IsCancelled.Value);
            }

            return sales.Select(s => new SaleDto
            {
                Id = s.Id,
                SaleNumber = s.SaleNumber,
                TotalAmount = s.TotalAmount,
                IsCancelled = s.IsCancelled
            });
        }
    }
}