using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly List<Sale> _sales = new List<Sale>();

        public Task<Sale> GetByIdAsync(Guid id)
        {
            var sale = _sales.Find(s => s.Id == id);
            return Task.FromResult(sale!);
        }

        public Task<IEnumerable<Sale>> GetAllAsync()
        {
            return Task.FromResult((IEnumerable<Sale>)_sales);
        }

        public Task AddAsync(Sale sale)
        {
            _sales.Add(sale);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Sale sale)
        {
            var existingSale = _sales.Find(s => s.Id == sale.Id);
            if (existingSale != null)
            {
                _sales.Remove(existingSale);
                _sales.Add(sale);
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var sale = _sales.Find(s => s.Id == id);
            if (sale != null)
            {
                _sales.Remove(sale);
            }
            return Task.CompletedTask;
        }
    }
}