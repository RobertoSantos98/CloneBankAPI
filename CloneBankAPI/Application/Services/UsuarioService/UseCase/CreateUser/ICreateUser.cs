using CloneBankAPI.Application.Request;
using CloneBankAPI.Domain.Models;

namespace CloneBankAPI.Application.Services.UsuarioService.UseCase.CreateUser
{
    public interface ICreateUser
    {

        Task<ResponseModel<bool>> ExecuteAsync(UsuarioRequest request);   
    }
}
