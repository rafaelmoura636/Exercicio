using NSubstitute.Core;
using Questao5.Domain.Entities;
using Questao5.Domain.Entities.ContaUsuario;
using System.Net;
using System.Web.Http;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("MovimentacaoContaCorrente")]
    public class MovimentacaoContaCorrenteController : ApiController
    {
        UsuarioAccount Account;
        [Route("MovimentarConta")]
        [HttpPost]
        public IHttpActionResult MovimentarContaCorrente(MovimentacaoRequest request)
        {
            // Validação da conta corrente cadastrada
            if (!ContaCorrenteCadastrada(request.IdContaCorrente))
            {
                return Content(HttpStatusCode.BadRequest, new ErroResponse("Conta corrente inválida", "INVALID_ACCOUNT"));
            }

            // Validação da conta corrente ativa
            if (!ContaCorrenteAtiva(request.IdContaCorrente))
            {
                return Content(HttpStatusCode.BadRequest, new ErroResponse("Conta corrente inativa", "INACTIVE_ACCOUNT"));
            }

            // Validação do valor positivo
            if (request.Valor <= 0)
            {
                return Content(HttpStatusCode.BadRequest, new ErroResponse("Valor inválido", "INVALID_VALUE"));
            }

            // Validação do tipo de movimento
            if (request.TipoMovimento != "C" && request.TipoMovimento != "D")
            {
                return Content(HttpStatusCode.BadRequest, new ErroResponse("Tipo de movimento inválido", "INVALID_TYPE"));
            }

            // Persistir a movimentação na tabela MOVIMENTO
            int idMovimento = PersistirMovimentacao(request);

            // Retornar o ID do movimento gerado
            return Ok(new MovimentacaoResponse(idMovimento));
        }

        private bool ContaCorrenteCadastrada(int identificacaoContaCorrente)
        {
            Account = new UsuarioAccount();
            // Lógica para verificar se a conta corrente está cadastrada
            // Retorna true se estiver cadastrada, false caso contrário
            // Implementação de exemplo:
            if (Account.IdAccount == (int)identificacaoContaCorrente)
            {
                return true;
            }
            else { return false; }
        }

        private bool ContaCorrenteAtiva(int identificacaoContaCorrente)
        {
            // Lógica para verificar se a conta corrente está ativa
            // Retorna true se estiver ativa, false caso contrário
            // Implementação de exemplo:
            if (Account.AcctiveAccount == 1)
            {
                return true;
            }
            else { return false; }
        }

        private int PersistirMovimentacao(MovimentacaoRequest request)
        {
            // Lógica para persistir a movimentação na tabela MOVIMENTO
            // Retorna o ID do movimento gerado
            // Implementação de exemplo:
            int idMovimento = GerarIdMovimento();
            // ... persistir o movimento na tabela MOVIMENTO ...
            return idMovimento;
        }

        private int GerarIdMovimento()
        {
            // Lógica para gerar um ID único para o movimento
            // Implementação de exemplo:
            return new Random().Next(1000, 9999);
        }

    }

}
