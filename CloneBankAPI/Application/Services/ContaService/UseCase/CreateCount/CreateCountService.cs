using CloneBankAPI.Application.Request;
using CloneBankAPI.Infrastructure.Repositories.ContaRepository;
using CloneBankAPI.Application.Util.Validation;
using CloneBankAPI.Domain.Models;
using CloneBankAPI.Domain.DTOs;

namespace CloneBankAPI.Application.Services.ContaService.UseCase.CreateCount
{
    public class CreateCountService : ICreateCountService
    {
        private readonly IContaRepository _contaRepository;
        public CreateCountService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }


        public async Task<ResponseModel<bool>> CriarConta(ContaRequest request)
        {
            //if(ValidationCreateCount.Validar(request))
            //    return ResponseModel<bool>.Failure("Os dados não estão completos ou válidos.");

            var usuario = await _contaRepository.BuscarContasPorIdUsuario(request.IdUsuario);

            if (usuario.Contas is not null)
            {
                foreach (var verificarConta in usuario.Contas)
                {
                    if(verificarConta.TipoConta == request.TipoConta)
                        return ResponseModel<bool>.Failure("O usuário já possui uma conta do tipo " + request.TipoConta.ToString() + ".");
                }
            }

            var conta = new Conta(
                    request.ApelidoConta,
                    request.TipoConta,
                    request.Saldo,
                    request.IdUsuario
                );

            await _contaRepository.CriarConta(conta);
            await _contaRepository.CommitAsync();
            
            return ResponseModel<bool>.Success(true);
        }
    }
}
