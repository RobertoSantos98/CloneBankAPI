using CloneBankAPI.Domain.DTOs;
using CloneBankAPI.Domain.Models;

namespace CloneBankAPI.Infrastructure.Repositories.ContaRepository
{
    public interface IContaRepository
    {
        Task CriarConta(Conta conta);
        Task<List<Conta>> BuscarContaCPF(string cpf);
        Task<List<Conta>> BuscarContaEmail(string email);
        Task<Usuario?> BuscarContasPorIdUsuario(Guid id);
        Task CommitAsync();
        Task UpdateConta(Conta conta);
    }
}
