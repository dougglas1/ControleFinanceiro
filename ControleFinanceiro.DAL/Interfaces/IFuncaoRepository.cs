using ControleFinanceiro.BLL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IFuncaoRepository : IRepositoryGeneric<Funcao>
    {
        Task CriarFuncao(Funcao funcao);
        Task AlterarFuncao(Funcao funcao);
        IQueryable<Funcao> FiltrarFuncoes(string nomeFuncao);
    }
}
