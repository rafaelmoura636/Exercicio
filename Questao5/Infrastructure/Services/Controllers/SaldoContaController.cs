using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Handlers;
using Questao5.Domain.Entities;
using System.Web.Http;

namespace Questao5.Infrastructure.Services.Controllers
{
    [System.Web.Http.Route("SaldoConta")]
    public class SaldoContaController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("ConsultarSlado")]
        public SaldoContarResponse ConsultarSlado(
            [FromServices] ISaldoContaHandle handler,
            [System.Web.Http.FromBody] SaldoContaRequest command
            )
        {
            return handler.Handle(command);
        }
    }
}
