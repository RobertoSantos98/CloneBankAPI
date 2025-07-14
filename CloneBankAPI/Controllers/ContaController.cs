using CloneBankAPI.Application.Request;
using CloneBankAPI.Application.Services.ContaService.UseCase.CreateCount;
using Microsoft.AspNetCore.Mvc;

namespace CloneBankAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly ICreateCountService _criarContaService;

        public ContaController(ICreateCountService criarContaService)
        {
            _criarContaService = criarContaService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarConta(ContaRequest request)
        {
            var result = await _criarContaService.CriarConta(request);
            
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Created();

        }
    }
}
