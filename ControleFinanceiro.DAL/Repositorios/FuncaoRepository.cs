using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class FuncaoRepository : RepositoryGeneric<Funcao>, IFuncaoRepository
    {
        private readonly Contexto _contexto;
        private readonly RoleManager<Funcao> _gerenciadorFuncoes;
        
        public FuncaoRepository(Contexto contexto, RoleManager<Funcao> gerenciadorFuncoes) : base(contexto)
        {
            _contexto = contexto;
            _gerenciadorFuncoes = gerenciadorFuncoes;
        }

        public async Task CriarFuncao(Funcao funcao)
        {
            try
            {
                await _gerenciadorFuncoes.CreateAsync(funcao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task AlterarFuncao(Funcao funcao)
        {
            try
            {
                Funcao entity = await BuscarPorId(funcao.Id);
                entity.Name = funcao.Name;
                entity.NormalizedName = funcao.NormalizedName;
                entity.Descricao = funcao.Descricao;
                
                await _gerenciadorFuncoes.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public IQueryable<Funcao> FiltrarFuncoes(string nomeFuncao)
        {
            try
            {
                var entity = _contexto.Funcoes.Where(c => c.Name.Contains(nomeFuncao));
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
