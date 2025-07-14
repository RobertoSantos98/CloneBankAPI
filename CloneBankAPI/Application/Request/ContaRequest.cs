using CloneBankAPI.Domain.Models;
using CloneBankAPI.Domain.Types;

namespace CloneBankAPI.Application.Request
{
    public class ContaRequest
    {
        public string ApelidoConta { get; set; }
        public TipoConta TipoConta { get; set; }
        public decimal Saldo { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
