using CloneBankAPI.Domain.DTOs;
using CloneBankAPI.Domain.Models;

namespace CloneBankAPI.Application.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioDTO ToMapUsuarioDTO(this Usuario usuario)
        {
            var contas = usuario.Contas?
                .Select(c => new ContaDTO(c.Id, c.ApelidoConta, c.TipoConta, c.Saldo)).ToList() ?? new List<ContaDTO>();

            return new UsuarioDTO(
                    usuario.Id,
                    usuario.FirstName,
                    usuario.LastName,
                    usuario.DateOfBirth,
                    usuario.CPF,
                    usuario.Email,
                    usuario.PasswordHashed,
                    contas
                );
        }
    }
}
