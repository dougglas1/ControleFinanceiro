using ControleFinanceiro.BLL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface ICategoriaRepository : IRepositoryGeneric<Categoria>
    {
        new IQueryable<Categoria> BuscarTodos();
        new Task<Categoria> BuscarPorId(int id);
        IQueryable<Categoria> FiltrarCategorias(string nomeCategoria);
        IQueryable<Categoria> BuscarCategoriasPorTipo(string tipo);
    }
}
