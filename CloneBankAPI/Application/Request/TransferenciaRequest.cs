using CloneBankAPI.Domain.Types;

namespace CloneBankAPI.Application.Request
{
    public class TransferenciaRequest
    {
        public Guid IdPagador { get; set; }
        public TipoConta tipoContaPagador { get; set; }
        public Guid IdRecebedor { get; set; }
        public TipoConta tipoContaRecebedor { get; set; }
        public decimal Valor { get; set; }
    }
}
