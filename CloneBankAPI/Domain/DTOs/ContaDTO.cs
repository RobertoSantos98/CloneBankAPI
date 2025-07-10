using CloneBankAPI.Domain.Types;

namespace CloneBankAPI.Domain.DTOs
{
    public record ContaDTO(Guid id, string ApelidoConta, TipoConta TipoConta, decimal Saldo);
    
}
