using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Handlers;
using Questao5.Domain.Entities;
using System.Web.Http;

namespace Questao5.Infrastructure.Services.Controllers
{
    [System.Web.Http.Route("MovimentacaoContaCorrente")]
    public class MovimentacaoContaCorrenteController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("MovimentarConta")]
        public MovimentacaoResponse MovimentarConta(
            [FromServices] IMovimentacaoHandler handler,
            [System.Web.Http.FromBody]MovimentacaoRequest command
            )
        {
            return handler.Handle( command );
        }

    }

}
