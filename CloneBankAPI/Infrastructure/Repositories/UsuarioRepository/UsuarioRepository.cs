using CloneBankAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CloneBankAPI.Infrastructure.Repositories.UsuarioRepository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbConnection _context;

        public UsuarioRepository(DbConnection context)
        {
            _context = context;
        }


        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await _context.AddAsync(usuario);
        }

        public async Task<List<Usuario>> GetAllUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioByEmail(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario?> GetUsuarioByCPF(string cpf)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.CPF == cpf);
        }

        public async Task<Usuario?> GetUsuarioById(Guid id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task CommitChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
