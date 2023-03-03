using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using Services.Models;
using System.Threading.Tasks;

namespace CalculoCDB.Controllers
{
    [ApiController]
    [Route("CDB")]

    public class CDBController : ControllerBase
    {
        private readonly ICDBService _CDBService;
        
        private readonly ILogger<CDBController> _logger;
       
        public CDBController(ILogger<CDBController> logger, ICDBService CDBService)
        {
            _logger = logger;
            _CDBService = CDBService;
        }

        [HttpPost("calcularInvestimento")]
        public async Task<decimal> CalcularInvestimento([FromBody] InvestimentCDBModel investimentCDBModel)
        {
            _logger.LogDebug("Inicio do método CalcularInvestimento ");
            return await _CDBService.CalcularCDBInvestimento(investimentCDBModel);
        }

    }
}
