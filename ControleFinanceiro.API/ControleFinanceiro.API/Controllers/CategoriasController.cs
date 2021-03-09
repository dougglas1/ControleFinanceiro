using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        
        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        // GET: api/Categorias
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _categoriaRepository.BuscarTodos().ToListAsync();
        }

        // GET: api/Categorias/5
        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _categoriaRepository.BuscarPorId(id);
            
            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/5
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _categoriaRepository.Alterar(categoria);

                return Ok(new
                {
                    mensagem = $"Categoria {categoria.Nome} alterada com sucesso"
                });
            }
            
            return BadRequest(ModelState);
        }

        // POST: api/Categorias
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaRepository.Criar(categoria);

                return Ok(new
                {
                    mensagem = $"Categoria {categoria.Nome} criada com sucesso"
                });
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/Categorias/5
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> DeleteCategoria(int id)
        {
            var categoria = await _categoriaRepository.BuscarPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }
            
            await _categoriaRepository.Remover(id);

            return Ok(new
            {
                mensagem = $"Categoria {categoria.Nome} removida com sucesso"
            });
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("FiltrarCategorias/{nomeCategoria}")]
        public async Task<ActionResult<IEnumerable<Categoria>>> FiltrarCategorias(string nomeCategoria)
        {
            return await _categoriaRepository.FiltrarCategorias(nomeCategoria).ToListAsync();
        }

        [Authorize]
        [HttpGet("FiltrarCategoriasDespesas")]
        public async Task<ActionResult<IEnumerable<Categoria>>> FiltrarCategoriasDespesas()
        {
            return await _categoriaRepository.BuscarCategoriasPorTipo("Despesa").ToListAsync();
        }
        
        [Authorize]
        [HttpGet("FiltrarCategoriasGanhos")]
        public async Task<ActionResult<IEnumerable<Categoria>>> FiltrarCategoriasGanhos()
        {
            return await _categoriaRepository.BuscarCategoriasPorTipo("Ganho").ToListAsync();
        }
    }
}
