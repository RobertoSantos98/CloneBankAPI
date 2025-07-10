namespace CloneBankAPI.Application.Util.PasswordHash
{
    public interface PasswordHashInterface
    {
        public string Hash(string senha);

        public bool Verificar(string senha, string senhaHashed);

    }
}
