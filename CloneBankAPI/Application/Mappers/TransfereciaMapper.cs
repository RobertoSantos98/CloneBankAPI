using CloneBankAPI.Domain.DTOs;
using CloneBankAPI.Domain.Models;

namespace CloneBankAPI.Application.Mappers
{
    public static class TransfereciaMapper
    {
        public static TransferenciaDTO ToMapTranferenciaDTO(this Transferencia transferencia)
        {
            return new TransferenciaDTO(
                    transferencia.Id,
                    transferencia.Pagador.ToMapContaDTO(),
                    transferencia.Recebedor.ToMapContaDTO(),
                    transferencia.Valor,
                    transferencia.DataTransferencia
                );
        }
    }
}
