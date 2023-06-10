using Dto;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.ExceptionHandling;

namespace ChatIntegrationsHunty.Api.Exceptions
{
    public class ExceptionHandler: IExceptionHandler
    {
        public IActionResult Handle(Exception ex)
        {
          return new ObjectResult(new ResponseDto<ObjectResult>() { Message = "Parece que hemos tenido un problema, Estamos trabajando para solucionarlo", IsSuccess = false, Data = null }) { StatusCode = 500 };
        }
    }
    public interface IExceptionHandler
    {
        public IActionResult Handle(Exception ex);
    }
}
