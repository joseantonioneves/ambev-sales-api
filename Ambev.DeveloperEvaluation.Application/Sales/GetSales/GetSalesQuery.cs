using MediatR;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public class GetSalesQuery : IRequest<IEnumerable<SaleDto>>
    {
        public bool? IsCancelled { get; set; } // Filtro opcional
    }
}