using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class TipoRepository : RepositoryGeneric<Tipo>, ITipoRepository
    {
        public TipoRepository(Contexto contexto) : base(contexto)
        {

        }
    }
}
