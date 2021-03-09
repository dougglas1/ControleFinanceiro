﻿using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Repositorios
{
    public class CategoriaRepository : RepositoryGeneric<Categoria>, ICategoriaRepository
    {
        private readonly Contexto _contexto;
        
        public CategoriaRepository(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
        
        public new IQueryable<Categoria> BuscarTodos()
        {
            try
            {
                return _contexto.Categorias.Include(c => c.Tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public new async Task<Categoria> BuscarPorId(int id)
        {
            try
            {
                var entity = await _contexto.Categorias.Include(c => c.Tipo).FirstOrDefaultAsync(c => c.CategoriaId == id);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Categoria> FiltrarCategorias(string nomeCategoria)
        {
            try
            {
                var entity = _contexto.Categorias.Include(c => c.Tipo).Where(c => c.Nome.Contains(nomeCategoria));
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public IQueryable<Categoria> BuscarCategoriasPorTipo(string tipo)
        {
            try
            {
                return _contexto.Categorias.Include(c => c.Tipo).Where(c => c.Tipo.Nome == tipo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}