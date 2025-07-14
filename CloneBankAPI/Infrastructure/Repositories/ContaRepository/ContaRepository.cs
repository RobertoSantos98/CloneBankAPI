using CloneBankAPI.Domain.DTOs;
using CloneBankAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloneBankAPI.Infrastructure.Repositories.ContaRepository
{
    public class ContaRepository : IContaRepository
    {
        private readonly DbConnection _context;

        public ContaRepository(DbConnection context)
        {
            _context = context;
        }


        public async Task<List<Conta?>> BuscarContaCPF(string cpf)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.CPF == cpf);

            return usuario.Contas.ToList();
        }

        public async Task<List<Conta>> BuscarContaEmail(string email)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            return usuario.Contas.ToList();
        }

        public async Task<Usuario?> BuscarContasPorIdUsuario(Guid id)
        {
            return await _context.Usuarios.Include(c => c.Contas).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task CriarConta(Conta conta)
        {
            await _context.AddAsync(conta);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateConta(Conta conta)
        {
             _context.Update(conta);
        }
    }
}
