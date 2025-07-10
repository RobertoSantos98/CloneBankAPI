using CloneBankAPI.Domain.Types;

namespace CloneBankAPI.Domain.Models
{
    public class Conta
    {
        public Guid Id { get; private set; }
        public string ApelidoConta { get; private set; }
        public TipoConta TipoConta { get; private set; }
        public decimal Saldo { get; private set; }
        public Usuario Usuario { get; private set; }
        public Guid IdUsuario { get; private set; }

        public Conta(string apelidoConta, TipoConta tipoConta, decimal saldo, Guid idUsuario)
        {
            Id = Guid.NewGuid();
            ApelidoConta = apelidoConta;
            TipoConta = tipoConta;
            Saldo = saldo;
            IdUsuario = idUsuario;
        }

        public void Creditar(decimal valor)
        {
            Saldo += valor;
        }

        public void Debitar(decimal valor)
        {
            if(valor > Saldo)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar essa operação");
            }

            Saldo -= valor;
        }

    }
}
