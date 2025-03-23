using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Interface que define os métodos para operações de persistência de vendas.
    /// </summary>
    public interface ISaleRepository
    {
        /// <summary>
        /// Obtém uma venda pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único da venda.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona. O resultado contém a venda encontrada ou null se não existir.</returns>
        Task<Sale> GetByIdAsync(Guid id);

        /// <summary>
        /// Obtém todas as vendas cadastradas.
        /// </summary>
        /// <returns>Uma tarefa que representa a operação assíncrona. O resultado contém uma lista de vendas.</returns>
        Task<IEnumerable<Sale>> GetAllAsync();

        /// <summary>
        /// Adiciona uma nova venda ao repositório.
        /// </summary>
        /// <param name="sale">A venda a ser adicionada.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task AddAsync(Sale sale);

        /// <summary>
        /// Atualiza uma venda existente no repositório.
        /// </summary>
        /// <param name="sale">A venda com os dados atualizados.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task UpdateAsync(Sale sale);

        /// <summary>
        /// Remove uma venda do repositório pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único da venda a ser removida.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        Task DeleteAsync(Guid id);
    }
}