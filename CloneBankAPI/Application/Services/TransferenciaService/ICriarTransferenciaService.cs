using CloneBankAPI.Application.Request;
using CloneBankAPI.Domain.DTOs;
using CloneBankAPI.Domain.Models;

namespace CloneBankAPI.Application.Services.TransferenciaService
{
    public interface ICriarTransferenciaService
    {
        Task<ResponseModel<TransferenciaDTO>> ExecuteAsync(TransferenciaRequest request);
    }
}
