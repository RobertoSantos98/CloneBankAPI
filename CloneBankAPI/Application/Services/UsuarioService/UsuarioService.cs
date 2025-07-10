using CloneBankAPI.Application.Mappers;
using CloneBankAPI.Domain.DTOs;
using CloneBankAPI.Domain.Models;
using CloneBankAPI.Infrastructure.Repositories.UsuarioRepository;

namespace CloneBankAPI.Application.Services.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public async Task<ResponseModel<List<UsuarioDTO>>> ListarUsuariosAsync()
        {

            var response = await _usuarioRepository.GetAllUsuario();

            if(response == null)
                return ResponseModel<List<UsuarioDTO>>.Failure("Ocorreu um erro ao tentar listar Usuários.");

            if (response.Count == 0)
                return ResponseModel<List<UsuarioDTO>>.Failure("Nenhum usuário encontrado.");

            return ResponseModel<List<UsuarioDTO>>.Success(response.Select(u => u.ToMapUsuarioDTO()).ToList());

        }
    }
}
