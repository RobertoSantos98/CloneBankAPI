using Microsoft.AspNetCore.Identity;

namespace CloneBankAPI.Application.Util.PasswordHash
{
    public class PasswordHash : PasswordHashInterface
    {

        private readonly PasswordHasher<object> _hasher = new();

        public string Hash(string senha)
        {
            return _hasher.HashPassword(null, senha);
        }

        public bool Verificar(string senha, string senhaHashed)
        {
            var result = _hasher.VerifyHashedPassword(null, senhaHashed, senha);
            return result == PasswordVerificationResult.Success;
        }
    }
}
