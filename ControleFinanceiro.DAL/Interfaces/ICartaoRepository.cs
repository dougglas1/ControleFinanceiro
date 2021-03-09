using ControleFinanceiro.BLL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface ICartaoRepository : IRepositoryGeneric<Cartao>
    {
        IQueryable<Cartao> BuscarCartoesPorUsuarioId(string usuarioId);

        IQueryable<Cartao> FiltrarCartoes(string numeroCartao);

        Task<int> BuscarQuantidadeCartoesPorUsuarioId(string usuarioId);
    }
}
