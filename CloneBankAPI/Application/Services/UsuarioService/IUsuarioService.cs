using CloneBankAPI.Domain.DTOs;
using CloneBankAPI.Domain.Models;

namespace CloneBankAPI.Application.Services.UsuarioService
{
    public interface IUsuarioService
    {
        Task<ResponseModel<List<UsuarioDTO>>> ListarUsuariosAsync();
    }
}
