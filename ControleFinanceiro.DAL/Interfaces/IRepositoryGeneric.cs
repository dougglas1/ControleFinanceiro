using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IRepositoryGeneric<TEntity> where TEntity : class
    {
        IQueryable<TEntity> BuscarTodos();
        Task<TEntity> BuscarPorId(int id);
        Task<TEntity> BuscarPorId(string id);
        Task Criar(TEntity entity);
        Task Criar(List<TEntity> entity);
        Task Alterar(TEntity entity);
        Task Remover(int id);
        Task Remover(string id);
        Task Remover(TEntity entity);
    }
}
