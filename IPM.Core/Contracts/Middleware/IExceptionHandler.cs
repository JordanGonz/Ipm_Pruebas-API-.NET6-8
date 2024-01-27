using Microsoft.AspNetCore.Http;

namespace IPM.Core.Contracts.Middleware
{
    public interface IExceptionHandler
    {
        Task HandleAsync(HttpContext context, Exception exception);
    }
}
