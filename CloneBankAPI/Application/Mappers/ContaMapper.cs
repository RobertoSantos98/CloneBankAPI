using CloneBankAPI.Domain.DTOs;
using CloneBankAPI.Domain.Models;

namespace CloneBankAPI.Application.Mappers
{
    public static class ContaMapper
    {
        public static ContaDTO ToMapContaDTO(this Conta conta)
        {
            return new ContaDTO(
                conta.Id,
                conta.ApelidoConta,
                conta.TipoConta,
                conta.Saldo
            );
        }

    }
}
