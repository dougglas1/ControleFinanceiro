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
    public class CartoesController : ControllerBase
    {
        private readonly ICartaoRepository _cartaoRepository;
        private readonly IDespesaRepository _despesaRepository;

        public CartoesController(ICartaoRepository cartaoRepository, IDespesaRepository despesaRepository)
        {
            _cartaoRepository = cartaoRepository;
            _despesaRepository = despesaRepository;
        }

        [HttpGet("BuscarCartoesPorUsuarioId/{usuarioId}")]
        public async Task<IEnumerable<Cartao>> PegarCartoesPeloUsuarioId(string usuarioId)
        {
            return await _cartaoRepository.BuscarCartoesPorUsuarioId(usuarioId).ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Cartao>> GetCartao(int id)
        {
            Cartao cartao = await _cartaoRepository.BuscarPorId(id);

            if (cartao == null)
                return NotFound();

            return cartao;
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCartao(int id, Cartao cartao)
        {
            if (id != cartao.CartaoId)
            {
                return BadRequest("Cartões diferentes. Não foi possível atualizar");
            }

            if (ModelState.IsValid)
            {
                await _cartaoRepository.Alterar(cartao);

                return Ok(new
                {
                    mensagem = $"Cartão número {cartao.Numero} atualizado com sucesso"
                });
            }

            return BadRequest(cartao);
        }

        [HttpPost]
        public async Task<ActionResult> PostCartao(Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                await _cartaoRepository.Criar(cartao);

                return Ok(new
                {
                    mensagem = $"Cartão número {cartao.Numero} criado com sucesso"
                });
            }

            return BadRequest(cartao);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCartao(int id)
        {
            Cartao cartao = await _cartaoRepository.BuscarPorId(id);

            if (cartao == null)
                return NotFound();
            
            IEnumerable<Despesa> despesas = await _despesaRepository.BuscarDespesasPorCartaoId(cartao.CartaoId);
            _despesaRepository.RemoverDespesas(despesas);
            
            await _cartaoRepository.Remover(cartao);


            return Ok(new
            {
                mensagem = $"Cartão número {cartao.Numero} excluído com sucesso"
            });
        }
        
        [HttpGet("FiltrarCartoes/{numeroCartao}")]
        public async Task<IEnumerable<Cartao>> FiltrarCartoes(string numeroCartao)
        {
            return await _cartaoRepository.FiltrarCartoes(numeroCartao).ToListAsync();
        }
    }
}
