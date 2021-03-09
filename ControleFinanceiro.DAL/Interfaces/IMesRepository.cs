using ControleFinanceiro.BLL.Models;
using System.Linq;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IMesRepository : IRepositoryGeneric<Mes>
    {
        new IQueryable<Mes> BuscarTodos();
    }
}
