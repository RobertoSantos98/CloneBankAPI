namespace CloneBankAPI.Domain.Models
{
    public class Transferencia
    {
        public Guid Id { get; private set; }
        public Guid IdPagador { get; private set; }
        public Conta Pagador { get; private set; }
        public Guid IdRecebedor { get; private set; }
        public Conta Recebedor { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataTransferencia { get; private set; }

        public Transferencia(Guid idPagador, Guid idRecebedor, decimal valor)
        {
            IdPagador = idPagador;
            IdRecebedor = idRecebedor;
            Valor = valor;
            DataTransferencia = DateTime.UtcNow;
        }

    }
}
