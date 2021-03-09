using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        private readonly IDespesaRepository _despesaRepository;
        public DespesasController(IDespesaRepository despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }
        
        [HttpGet("BuscarDespesasPorUsuarioId/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Despesa>>> PegarDespesasPeloUsuarioId(string usuarioId)
        {
            return await _despesaRepository.BuscarDespesasPorUsuarioId(usuarioId).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Despesa>> GetDespesa(int id)
        {
            Despesa despesa = await _despesaRepository.BuscarPorId(id);

            if (despesa == null)
                return NotFound();
            
            return despesa;
        }

        [HttpPost]
        public async Task<ActionResult<Despesa>> PostDespesa(Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                await _despesaRepository.Criar(despesa);

                return Ok(new
                {
                    mensagem = $"Despesa no valor de R$ {despesa.Valor} criada com sucesso"
                });
            }

            return BadRequest(despesa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Despesa>> PutDespesa(int id, Despesa despesa)
        {
            if (id != despesa.DespesaId)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _despesaRepository.Alterar(despesa);

                return Ok(new
                {
                    mensagem = $"Despesa no valor de R$ {despesa.Valor} atualizada com sucesso"
                });
            }

            return BadRequest(despesa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDespesa(int id)
        {
            Despesa despesa = await _despesaRepository.BuscarPorId(id);

            if (despesa == null)
            {
                return NotFound();
            }

            await _despesaRepository.Remover(despesa);

            return Ok(new
            {
                mensagem = $"Despesa no valor de R$ {despesa.Valor} excluída com sucesso"
            });
        }

        [HttpGet("FiltrarDespesas/{nomeCategoria}")]
        public async Task<IEnumerable<Despesa>> FiltrarDespesas(string nomeCategoria)
        {
            return await _despesaRepository.FiltrarDespesas(nomeCategoria).ToListAsync();
        }
    }
}
