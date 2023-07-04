using Questao5.Domain.Entities;
using System.Net;
using System.Security.Cryptography;
using System.Web.Http;
using Dapper;
using System.Data;
using Microsoft.Data.Sqlite;
using MongoDB.Driver.Core.Configuration;
using System.Data.Common;
using System.Text;

namespace Questao5.Application.Handlers
{
    public class MovimentacaoHandler : IMovimentacaoHandler
    {
        string _Connection = "StringDeConexaoComOBanco";
        public MovimentacaoResponse Handle(MovimentacaoRequest request)
        {
            //Verificação da Movimentação
            // Validação da conta corrente cadastrada
            if (!ContaCorrenteCadastrada(request.IdContaCorrente))
            {
                return new MovimentacaoResponse("", HttpStatusCode.BadRequest, new ErroResponse("Conta corrente inválida", "INVALID_ACCOUNT"));
            }

            // Validação da conta corrente ativa
            if (!ContaCorrenteAtiva(request.IdContaCorrente))
            {
                return new MovimentacaoResponse("", HttpStatusCode.BadRequest, new ErroResponse("Conta corrente inativa", "INACTIVE_ACCOUNT"));
            }

            // Validação do valor positivo
            if (request.Valor <= 0)
            {
                return new MovimentacaoResponse("", HttpStatusCode.BadRequest, new ErroResponse("Valor inválido", "INVALID_VALUE"));
            }

            // Validação do tipo de movimento
            if (request.TipoMovimento != "C" && request.TipoMovimento != "D")
            {
                return new MovimentacaoResponse("", HttpStatusCode.BadRequest, new ErroResponse("Tipo de movimento inválido", "INVALID_TYPE"));
            }
            //Substituir por um Id de Movimentação vindo do banco
            return new MovimentacaoResponse(MovimentarContaCorrente(request));

        }

        private bool ContaCorrenteCadastrada(string identificacaoContaCorrente)
        {
            IDataReader reader;
            // Lógica para verificar se a conta corrente está cadastrada
            using (IDbConnection connection = _Connection)
            {
                reader = connection.ExecuteReader("Select * from contacorrente where idcontacorrente = '" + identificacaoContaCorrente + "'");
                if (reader.Read())
                {
                    // Retorna true se estiver cadastrada, false caso contrário
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool ContaCorrenteAtiva(string identificacaoContaCorrente)
        {
            // Lógica para verificar se a conta corrente está ativa
            IDataReader reader;
            // Lógica para verificar se a conta corrente está cadastrada
            using (IDbConnection connection = _Connection)
            {
                reader = connection.ExecuteReader("Select ativo * from contacorrente where idcontacorrente = '" + identificacaoContaCorrente + "'");
                if (reader.Read())
                {
                    if (reader.GetInt32(0) == 1)
                        // Retorna true se estiver cadastrada, false caso contrário
                        return true;
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
        }

        public string MovimentarContaCorrente(MovimentacaoRequest request)
        {
            // Persistir a movimentação na tabela MOVIMENTO
            string idMovimento = PersistirMovimentacao(request);

            // Retornar o ID do movimento gerado
            return idMovimento;
        }

        private string PersistirMovimentacao(MovimentacaoRequest request)
        {
            // Retorna o ID do movimento gerado
            string idMovimento = GerarIdMovimento();
            // ... persistir o movimento na tabela MOVIMENTO ...
            return idMovimento;
        }

        private string GerarIdMovimento()
        {
            // Lógica para gerar um ID único para o movimento
            // Implementação de exemplo:
            return "";
        }
    }
}
