using CloneBankAPI.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace CloneBankAPI.Infrastructure.Repositories.TransferenciaRepository
{
    public interface ITransferenciaRepository
    {
        Task RealizarTransferencia(Transferencia transferencia);
        Task<Transferencia> ObterTransferenciaPorId(Guid transferenciaId);
        Task<Usuario> ProcurarUsuarioPorId(Guid usuarioId);
        Task<List<Transferencia>> ObterTransferenciasPorUsuario(Guid usuarioId);
        Task CommitChangesAsync();
        Task<IDbContextTransaction> ComecarTransferencia();
    }
}
