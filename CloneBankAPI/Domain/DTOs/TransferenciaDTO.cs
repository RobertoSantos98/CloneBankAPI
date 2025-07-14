using CloneBankAPI.Domain.Models;

namespace CloneBankAPI.Domain.DTOs
{
    public record TransferenciaDTO(
            Guid Id,
            ContaDTO Pagador,
            ContaDTO Recebedor,
            decimal Valor,
            DateTime DataTransferencia

        );
    
}
