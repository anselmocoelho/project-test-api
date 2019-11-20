namespace Project.Test.Application.Dto
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            Result = false;
        }

        public bool Result { get; set; }

        public string Message { get; set; }
    }
}