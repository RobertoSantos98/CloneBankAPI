namespace CloneBankAPI.Domain.Models
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public T ?Data { get; set; }

        public ResponseModel(bool success, string erroMessage, T dados)
        {
            IsSuccess = success;
            ErrorMessage = erroMessage;
            Data = dados;
        }

        private ResponseModel(bool suc)
        {
            IsSuccess = suc;
        }

        public static ResponseModel<T>Success(T data) => new ResponseModel<T>(true, null!, data);

        public static ResponseModel<T>Failure(string errorMessage) => new ResponseModel<T>(false, errorMessage, default!);



    }
}
