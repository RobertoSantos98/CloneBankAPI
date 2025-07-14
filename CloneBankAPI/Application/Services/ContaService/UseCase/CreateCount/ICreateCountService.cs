using CloneBankAPI.Application.Request;
using CloneBankAPI.Domain.Models;

namespace CloneBankAPI.Application.Services.ContaService.UseCase.CreateCount
{
    public interface ICreateCountService
    {
        Task<ResponseModel<bool>> CriarConta(ContaRequest request);
    }
}
