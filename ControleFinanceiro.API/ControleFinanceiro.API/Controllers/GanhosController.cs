using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GanhosController : ControllerBase
    {
        private readonly IGanhoRepository _ganhosRepository;

        public GanhosController(IGanhoRepository ganhosRepository)
        {
            _ganhosRepository = ganhosRepository;
        }
        
        [HttpGet("BuscarGanhosPorUsuarioId/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Ganho>>> PegarGanhosPeloUsuarioId(string usuarioId)
        {
            return await _ganhosRepository.BuscarGanhosPorUsuarioId(usuarioId).ToListAsync();
        }

        [HttpGet("{ganhoId}")]
        public async Task<ActionResult<Ganho>> GetGanho(int ganhoId)
        {
            Ganho ganho = await _ganhosRepository.BuscarPorId(ganhoId);

            if (ganho == null)
                return NotFound();

            return ganho;
        }

        [HttpPut("{ganhoId}")]
        public async Task<ActionResult> PutGanho(int ganhoId, Ganho ganho)
        {
            if (ganhoId != ganho.GanhoId)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _ganhosRepository.Alterar(ganho);

                return Ok(new
                {
                    mensagem = $"Ganho no valor de R$ {ganho.Valor} atualizado com sucesso"
                });
            }

            return BadRequest(ganho);
        }

        [HttpPost]
        public async Task<ActionResult<Ganho>> PostGanho(Ganho ganho)
        {
            if (ModelState.IsValid)
            {
                await _ganhosRepository.Criar(ganho);

                return Ok(new
                {
                    mensagem = $"Ganho no valor de R$ {ganho.Valor} inserido com sucesso"
                });
            }

            return BadRequest(ganho);
        }

        [HttpDelete("{ganhoId}")]
        public async Task<ActionResult> DeleteGanho(int ganhoId)
        {
            Ganho ganho = await _ganhosRepository.BuscarPorId(ganhoId);

            if (ganho == null)
                return NotFound();

            await _ganhosRepository.Remover(ganho);

            return Ok(new
            {
                mensagem = $"Ganho no valor de R$ {ganho.Valor} excluído com sucesso"
            });
        }

        [HttpGet("FiltrarGanhos/{nomeCategoria}")]
        public async Task<IEnumerable<Ganho>> FiltrarGanhos(string nomeCategoria)
        {
            return await _ganhosRepository.FiltrarGanhos(nomeCategoria).ToListAsync();
        }
    }
}
