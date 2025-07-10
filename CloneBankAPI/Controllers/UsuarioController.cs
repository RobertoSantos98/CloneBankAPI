using CloneBankAPI.Application.Request;
using CloneBankAPI.Application.Services.UsuarioService;
using CloneBankAPI.Application.Services.UsuarioService.UseCase.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace CloneBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ICreateUser _createUserService;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(ICreateUser createUser, IUsuarioService service)
        {
            _createUserService = createUser;
            _usuarioService = service;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(UsuarioRequest request)
        {
            var result = await _createUserService.ExecuteAsync(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            var result = await _usuarioService.ListarUsuariosAsync();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }


    }
}
