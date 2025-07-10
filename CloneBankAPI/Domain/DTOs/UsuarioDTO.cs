using CloneBankAPI.Domain.Models;

namespace CloneBankAPI.Domain.DTOs
{
    public record UsuarioDTO(
        Guid Id,
        string FirstName,
        string LastName,
        DateOnly DateOfBirth,
        string CPF,
        string Email,
        string PasswordHashed,
        List<ContaDTO> Contas = null! // Default to null, will be initialized in the Usuario model
        );
    
}
