using CloneBankAPI.Application.Request;
using CloneBankAPI.Application.Services.TransferenciaService;
using Microsoft.AspNetCore.Mvc;

namespace CloneBankAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferenciaController : ControllerBase
    {
        private readonly ICriarTransferenciaService _criarTransferenciaService;
        public TransferenciaController(ICriarTransferenciaService criarTransferenciaService)
        {
            _criarTransferenciaService = criarTransferenciaService;
        }

        [HttpPost]
        public async Task<IActionResult> RealizarTranferencia(TransferenciaRequest request)
        {
            var result = await _criarTransferenciaService.ExecuteAsync(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result);
        }
    }
}
