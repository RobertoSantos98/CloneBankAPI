using CloneBankAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CloneBankAPI.Infrastructure.Repositories.TransferenciaRepository
{
    public class TransferenciaRepository : ITransferenciaRepository
    {
        private readonly DbConnection _context;
        public TransferenciaRepository(DbConnection context)
        {
            _context = context;
        }

        public Task<Transferencia> ObterTransferenciaPorId(Guid transferenciaId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transferencia>> ObterTransferenciasPorUsuario(Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public async Task RealizarTransferencia(Transferencia transferencia)
        {
            await _context.AddAsync(transferencia);
        }

        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> ComecarTransferencia()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task<Usuario> ProcurarUsuarioPorId(Guid usuarioId)
        {
            return await _context.Usuarios.Include(u => u.Contas).FirstOrDefaultAsync(u => u.Id == usuarioId);
        }
    }

}
