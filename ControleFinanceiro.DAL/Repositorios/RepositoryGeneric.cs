using ControleFinanceiro.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class RepositoryGeneric<TEntity> : IRepositoryGeneric<TEntity> where TEntity : class
    {
        private readonly Contexto _contexto;
        
        public RepositoryGeneric(Contexto contexto)
        {
            _contexto = contexto;
        }
        
        public async Task Alterar(TEntity entity)
        {
            try
            {
                var registro = _contexto.Set<TEntity>().Update(entity);
                registro.State = EntityState.Modified;
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> BuscarPorId(int id)
        {
            try
            {
                var entity = await _contexto.Set<TEntity>().FindAsync(id);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> BuscarPorId(string id)
        {
            try
            {
                var entity = await _contexto.Set<TEntity>().FindAsync(id);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<TEntity> BuscarTodos()
        {
            try
            {
                return _contexto.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Criar(TEntity entity)
        {
            try
            {
                await _contexto.AddAsync(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Criar(List<TEntity> entity)
        {
            try
            {
                await _contexto.AddRangeAsync(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Remover(int id)
        {
            try
            {
                var entity = await BuscarPorId(id);
                _contexto.Set<TEntity>().Remove(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Remover(string id)
        {
            try
            {
                var entity = await BuscarPorId(id);
                _contexto.Set<TEntity>().Remove(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public async Task Remover(TEntity entity)
        {
            try
            {
                _contexto.Set<TEntity>().Remove(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
