using ControleFinanceiro.API.ViewModels;
using ControleFinanceiro.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ControleFinanceiro.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ICartaoRepository _cartaoRepository;
        private readonly IGanhoRepository _ganhosRepository;
        private readonly IDespesaRepository _despesaRepository;
        private readonly IMesRepository _mesRepository;
        private readonly IGraficoRepository _graficoRepository;

        public DashboardController(
            ICartaoRepository cartaoRepository, 
            IGanhoRepository ganhosRepository, 
            IDespesaRepository despesaRepository, 
            IMesRepository mesRepository, 
            IGraficoRepository graficoRepository)
        {
            _cartaoRepository = cartaoRepository;
            _ganhosRepository = ganhosRepository;
            _despesaRepository = despesaRepository;
            _mesRepository = mesRepository;
            _graficoRepository = graficoRepository;
        }
        
        [HttpGet("BuscarDadosCardsDashboard/{usuarioId}")]
        public async Task<ActionResult<DadosCardsDashboardViewModel>> PegarDadosCardsDashboard(string usuarioId)
        {
            int qtdCartoes = await _cartaoRepository.BuscarQuantidadeCartoesPorUsuarioId(usuarioId);
            double ganhoTotal = Math.Round(await _ganhosRepository.BuscarGanhoTotalPorUsuarioId(usuarioId), 2);
            double despesaTotal = Math.Round(await _despesaRepository.BuscarDespesaTotalPorUsuarioId(usuarioId), 2);
            double saldo = Math.Round(ganhoTotal - despesaTotal, 2);

            DadosCardsDashboardViewModel model = new DadosCardsDashboardViewModel
            {
                QtdCartoes = qtdCartoes,
                GanhoTotal = ganhoTotal,
                DespesaTotal = despesaTotal,
                Saldo = saldo
            };

            return model;
        }
        
        [HttpGet("BuscarDadosAnuaisPorUsuarioId/{usuarioId}/{ano}")]
        public object PegarDadosAnuaisPeloUsuarioId(string usuarioId, int ano)
        {
            return (new
            {
                ganhos = _graficoRepository.BuscarGanhosAnuaisPorUsuarioId(usuarioId, ano),
                despesas = _graficoRepository.BuscarDespesasAnuaisPorUsuarioId(usuarioId, ano),
                meses = _mesRepository.BuscarTodos()
            });
        }
    }
}
