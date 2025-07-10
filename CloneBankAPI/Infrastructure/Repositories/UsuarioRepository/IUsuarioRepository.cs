using CloneBankAPI.Domain.Models;

namespace CloneBankAPI.Infrastructure.Repositories.UsuarioRepository
{
    public interface IUsuarioRepository
    {
        Task AddUsuarioAsync(Usuario usuario);
        Task<List<Usuario>> GetAllUsuario();
        Task<Usuario?> GetUsuarioById(Guid id);
        Task<Usuario?> GetUsuarioByEmail(string email);
        Task<Usuario?> GetUsuarioByCPF(string cpf);
        Task CommitChanges();

    }
}
