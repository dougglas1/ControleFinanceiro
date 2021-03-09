using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using System;
using System.Linq;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class MesRepository : RepositoryGeneric<Mes>, IMesRepository
    {
        private readonly Contexto _contexto;

        public MesRepository(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
        
        public new IQueryable<Mes> BuscarTodos()
        {
            try
            {
                return _contexto.Meses.OrderBy(m => m.MesId);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
