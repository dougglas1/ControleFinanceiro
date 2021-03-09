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
    public class MesesController : ControllerBase
    {
        private readonly IMesRepository _mesRepository;
        
        public MesesController(IMesRepository mesRepository)
        {
            _mesRepository = mesRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mes>>> GetMeses()
        {
            return await _mesRepository.BuscarTodos().ToListAsync();
        }
    }
}
