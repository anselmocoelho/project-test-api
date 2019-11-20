namespace Project.Test.Application.Dto
{
    public class ServiceResponse<T> : ServiceResult
    {
        public T Object { get; set; }
    }
}