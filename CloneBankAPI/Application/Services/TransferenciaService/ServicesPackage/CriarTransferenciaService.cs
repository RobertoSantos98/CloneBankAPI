
using CloneBankAPI.Application.Mappers;
using CloneBankAPI.Application.Request;
using CloneBankAPI.Domain.DTOs;
using CloneBankAPI.Domain.Models;
using CloneBankAPI.Infrastructure.Repositories.ContaRepository;
using CloneBankAPI.Infrastructure.Repositories.TransferenciaRepository;
using CloneBankAPI.Infrastructure.Repositories.UsuarioRepository;

namespace CloneBankAPI.Application.Services.TransferenciaService.ServicesPackage
{
    public class CriarTransferenciaService : ICriarTransferenciaService
    {
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IContaRepository _contaRepository;
        public CriarTransferenciaService(ITransferenciaRepository transferenciaRepository, IUsuarioRepository usuarioRepository, IContaRepository contaRepository)
        {
            _transferenciaRepository = transferenciaRepository;
            _usuarioRepository = usuarioRepository;
            _contaRepository = contaRepository;
        }

        public async Task<ResponseModel<TransferenciaDTO>> ExecuteAsync(TransferenciaRequest request)
        {
            var pagador = await _transferenciaRepository.ProcurarUsuarioPorId(request.IdPagador);
            var recebedor = await _transferenciaRepository.ProcurarUsuarioPorId(request.IdRecebedor);

            if(pagador == null || recebedor == null)
                return ResponseModel<TransferenciaDTO>.Failure("Usuário pagador ou recebedor não encontrado.");

            var contaPagador = pagador.Contas.FirstOrDefault(c => c.TipoConta == request.tipoContaPagador);
            if(contaPagador == null)
                return ResponseModel<TransferenciaDTO>.Failure("Conta do pagador não encontrada ou tipo de conta inválido.");

            var contaRecebedor = recebedor.Contas.FirstOrDefault(c => c.TipoConta == request.tipoContaRecebedor);
            if(contaRecebedor == null)
                return ResponseModel<TransferenciaDTO>.Failure("Conta do recebedor não encontrada ou tipo de conta inválido.");


            contaPagador.Debitar(request.Valor);
            contaRecebedor.Creditar(request.Valor);

            var transferencia = new Transferencia(
                    contaPagador.Id,
                    contaRecebedor.Id,
                    request.Valor
                );

            using (var transacao = await _transferenciaRepository.ComecarTransferencia())
            {
                try
                {
                    var listaOperacoes = new List<Task>
                    {
                        _contaRepository.UpdateConta(contaPagador),
                        _contaRepository.UpdateConta(contaRecebedor),
                        _transferenciaRepository.RealizarTransferencia(transferencia)
                    };

                    await Task.WhenAll(listaOperacoes);

                    await _usuarioRepository.CommitChanges();
                    await _transferenciaRepository.CommitChangesAsync();

                    await transacao.CommitAsync();


                }catch(Exception e)
                {
                    await transacao.RollbackAsync();
                    return ResponseModel<TransferenciaDTO>.Failure("Erro ao processar a transferência: " + e.Message); 
                }
            }


            return ResponseModel<TransferenciaDTO>.Success(transferencia.ToMapTranferenciaDTO());

        }

    }
}
