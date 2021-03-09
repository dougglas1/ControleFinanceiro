using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using ControleFinanceiro.API.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace ControleFinanceiro.API.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncoesController : ControllerBase
    {
        private readonly IFuncaoRepository _funcaoRepository;
        
        public FuncoesController(IFuncaoRepository funcaoRepository)
        {
            _funcaoRepository = funcaoRepository;
        }

        // GET: api/Funcoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcao>>> GetFuncoes()
        {
            return await _funcaoRepository.BuscarTodos().ToListAsync();
        }
        
        // GET: api/Funcoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcao>> GetFuncao(string id)
        {
            var funcao = await _funcaoRepository.BuscarPorId(id);

            if (funcao == null)
            {
                return NotFound();
            }

            return funcao;
        }

        // PUT: api/Funcoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncao(string id, FuncaoViewModel funcao)
        {
            if (id != funcao.Id)
            {
                return BadRequest();
            }
            
            if (ModelState.IsValid)
            {
                Funcao entity = new Funcao
                {
                    Id = funcao.Id,
                    Name = funcao.Name,
                    Descricao = funcao.Descricao
                };
                
                await _funcaoRepository.AlterarFuncao(entity);

                return Ok(new
                {
                    mensagem = $"Função {funcao.Name} alterada com Sucesso"
                });
            }
            
            return BadRequest(ModelState);
        }

        // POST: api/Funcoes
        [HttpPost]
        public async Task<ActionResult<Funcao>> PostFuncao(FuncaoViewModel funcao)
        {
            if (ModelState.IsValid)
            {
                Funcao entity = new Funcao
                {
                    Name = funcao.Name,
                    Descricao = funcao.Descricao
                };

                await _funcaoRepository.CriarFuncao(entity);

                return Ok(new
                {
                    mensagem = $"Função {funcao.Name} criada com Sucesso"
                });
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/Funcoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Funcao>> DeleteFuncao(string id)
        {
            var funcao = await _funcaoRepository.BuscarPorId(id);
            if (funcao == null)
            {
                return NotFound();
            }

            await _funcaoRepository.Remover(funcao);
            
            return Ok(new
            {
                mensagem = $"Função {funcao.Name} removida com Sucesso"
            });
        }
        
        [HttpGet("FiltrarFuncoes/{nomeFuncao}")]
        public async Task<ActionResult<IEnumerable<Funcao>>> FiltrarFuncoes(string nomeFuncao)
        {
            return await _funcaoRepository.FiltrarFuncoes(nomeFuncao).ToListAsync();
        }
    }
}
