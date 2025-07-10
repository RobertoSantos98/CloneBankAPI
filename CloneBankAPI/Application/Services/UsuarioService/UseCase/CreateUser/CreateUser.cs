using CloneBankAPI.Application.Request;
using CloneBankAPI.Application.Util.PasswordHash;
using CloneBankAPI.Domain.Models;
using CloneBankAPI.Infrastructure.Repositories.UsuarioRepository;

namespace CloneBankAPI.Application.Services.UsuarioService.UseCase.CreateUser
{
    public class CreateUser : ICreateUser
    {
        private readonly IUsuarioRepository _repository;
        private readonly PasswordHashInterface _hashService;

        public CreateUser(IUsuarioRepository repository, PasswordHashInterface hashService)
        {
            _repository = repository;
            _hashService = hashService;
        }

        public async Task<ResponseModel<bool>> ExecuteAsync(UsuarioRequest request)
        {
            var verificarCPFExistente = await _repository.GetUsuarioByCPF(request.CPF);

            if(verificarCPFExistente is not null)
                return ResponseModel<bool>.Failure("CPF já cadastrado");

            var verificarEmailExistente = await _repository.GetUsuarioByEmail(request.Email);

            if(verificarEmailExistente != null)
                return ResponseModel<bool>.Failure("Usuário já existente");

            var passwordHashed = _hashService.Hash(request.Password);

            var usuario = new Usuario(request.FirstName, request.LastName, request.DateOfBirth,request.CPF, request.Email, passwordHashed);

            await _repository.AddUsuarioAsync(usuario);
            await _repository.CommitChanges();

            return ResponseModel<bool>.Success(true);

        }
    }
}
