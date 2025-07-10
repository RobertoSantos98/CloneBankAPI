using CloneBankAPI.Domain.Models;

namespace CloneBankAPI.Application.Request
{
    public class UsuarioRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
