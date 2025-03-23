using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, Guid>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleService _saleService;

        public CreateSaleHandler(ISaleRepository saleRepository, ISaleService saleService)
        {
            _saleRepository = saleRepository;
            _saleService = saleService;
        }

        public async Task<Guid> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = request.Sale;

            // Aplica regras de negócio
            _saleService.ValidateSale(sale);
            _saleService.ApplyDiscounts(sale);

            // Calcula o total da venda
            sale.TotalAmount = 0;
            foreach (var item in sale.Products)
            {
                sale.TotalAmount += item.ItemTotal;
            }

            // Salva a venda
            await _saleRepository.AddAsync(sale);

            return sale.Id;
        }
    }
}