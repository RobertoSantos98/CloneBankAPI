namespace CloneBankAPI.Domain.Models
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string PasswordHashed { get; private set; }
        public List<Conta> Contas { get; private set; } = new();

        public Usuario(string firstName, string lastName, DateOnly dateOfBirth, string cpf, string email, string passwordHashed)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            CPF = cpf;
            Email = email;
            PasswordHashed = passwordHashed;
        }

        public Usuario() { }


        public void AlterarSenha(string novaSenhaHashed)
        {
            PasswordHashed = novaSenhaHashed; 
        }




    }
}
