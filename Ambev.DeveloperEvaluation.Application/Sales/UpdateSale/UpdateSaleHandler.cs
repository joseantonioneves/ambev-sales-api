using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, Unit>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleService _saleService;

        public UpdateSaleHandler(ISaleRepository saleRepository, ISaleService saleService)
        {
            _saleRepository = saleRepository;
            _saleService = saleService;
        }

        public async Task<Unit> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var existingSale = await _saleRepository.GetByIdAsync(request.Id);
            
            if (request.UpdatedSale != null)
            {
                _saleService.ValidateSale(request.UpdatedSale);
                _saleService.ApplyDiscounts(request.UpdatedSale);

                await _saleRepository.UpdateAsync(request.UpdatedSale);
            }
            return Unit.Value;
        }
    }
}