using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class CartaoRepository : RepositoryGeneric<Cartao>, ICartaoRepository
    {
        private readonly Contexto _contexto;

        public CartaoRepository(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public IQueryable<Cartao> FiltrarCartoes(string numeroCartao)
        {
            try
            {
                return _contexto.Cartoes.Where(c => c.Numero.Contains(numeroCartao));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public IQueryable<Cartao> BuscarCartoesPorUsuarioId(string usuarioId)
        {
            try
            {
                return _contexto.Cartoes.Where(c => c.UsuarioId == usuarioId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public async Task<int> BuscarQuantidadeCartoesPorUsuarioId(string usuarioId)
        {
            try
            {
                return await _contexto.Cartoes.CountAsync(c => c.UsuarioId == usuarioId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
