using ControleFinanceiro.BLL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IDespesaRepository : IRepositoryGeneric<Despesa>
    {
        IQueryable<Despesa> BuscarDespesasPorUsuarioId(string usuarioId);

        void RemoverDespesas(IEnumerable<Despesa> despesas);

        Task<IEnumerable<Despesa>> BuscarDespesasPorCartaoId(int cartaoId);

        IQueryable<Despesa> FiltrarDespesas(string nomeCategoria);
        
        Task<double> BuscarDespesaTotalPorUsuarioId(string usuarioId);
    }
}
