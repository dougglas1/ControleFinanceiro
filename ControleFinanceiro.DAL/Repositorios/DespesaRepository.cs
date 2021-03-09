using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class DespesaRepository : RepositoryGeneric<Despesa>, IDespesaRepository
    {
        private readonly Contexto _contexto;

        public DespesaRepository(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
        
        public void RemoverDespesas(IEnumerable<Despesa> despesas)
        {
            try
            {
                _contexto.Despesas.RemoveRange(despesas);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Despesa> FiltrarDespesas(string nomeCategoria)
        {
            try
            {
                return _contexto.Despesas
                    .Include(d => d.Cartao).Include(d => d.Mes)
                    .Include(d => d.Categoria).ThenInclude(d => d.Tipo)
                    .Where(d => d.Categoria.Nome.Contains(nomeCategoria) && d.Categoria.Tipo.Nome == "Despesa");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public async Task<IEnumerable<Despesa>> BuscarDespesasPorCartaoId(int cartaoId)
        {
            try
            {
                return await _contexto.Despesas.Where(d => d.CartaoId == cartaoId).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Despesa> BuscarDespesasPorUsuarioId(string usuarioId)
        {
            try
            {
                return _contexto.Despesas.Include(d => d.Cartao).Include(c => c.Categoria).Include(c => c.Mes).Where(d => d.UsuarioId == usuarioId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<double> BuscarDespesaTotalPorUsuarioId(string usuarioId)
        {
            try
            {
                return await _contexto.Despesas.Where(d => d.UsuarioId == usuarioId).SumAsync(d => d.Valor);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
