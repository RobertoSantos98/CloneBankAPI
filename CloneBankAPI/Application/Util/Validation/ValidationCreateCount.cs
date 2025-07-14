using CloneBankAPI.Application.Request;

namespace CloneBankAPI.Application.Util.Validation
{
    public class ValidationCreateCount
    {
        public static bool Validar(ContaRequest request)
        {
            if(string.IsNullOrEmpty(request.ApelidoConta))
            {
                return false;
            }

            return true;
        }
    }
}
