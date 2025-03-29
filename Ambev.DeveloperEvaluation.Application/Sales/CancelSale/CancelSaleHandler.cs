using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, Unit>
    {
        private readonly ISaleRepository _saleRepository;

        public CancelSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Unit> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.Id);
            sale.IsCancelled = true;
            await _saleRepository.UpdateAsync(sale);
            return Unit.Value;
        }
    }
}