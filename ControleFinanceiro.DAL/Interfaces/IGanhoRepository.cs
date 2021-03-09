using ControleFinanceiro.BLL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IGanhoRepository : IRepositoryGeneric<Ganho>
    {
        IQueryable<Ganho> BuscarGanhosPorUsuarioId(string usuarioId);

        IQueryable<Ganho> FiltrarGanhos(string nomeCategoria);
        
        Task<double> BuscarGanhoTotalPorUsuarioId(string usuarioId);
    }
}
