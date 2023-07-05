using Dapper;
using FluentAssertions;
using NSubstitute.Routing.Handlers;
using Questao5.Domain.Entities;
using Questao5.Domain.Entities.ContaUsuario;
using System.Data;
using System.Net;

namespace Questao5.Application.Handlers
{
    public class SaldoContaHandle : ISaldoContaHandle
    {
        public SaldoContarResponse Handle(SaldoContaRequest request)
        {
            SaldoContarResponse contaResponse = new SaldoContarResponse();
            UsuarioAccount usuarioAccount = new UsuarioAccount();
            if (usuarioAccount == null)
            {
                return new SaldoContarResponse(HttpStatusCode.BadRequest, new ErroResponse("Apenas contas correntes cadastradas podem consultar o saldo", "INVALID_ACCOUNT"));
            }

            if (usuarioAccount.AcctiveAccount == 0)
            {
                return new SaldoContarResponse(HttpStatusCode.BadRequest, new ErroResponse("Apenas contas correntes ativas podem consultar o saldo", "INACTIVE_ACCOUNT"));
            }
            List<Movimentacoes> movimentacoes = ObterMovimentacoes(request.IdConta);
            if (movimentacoes != null)
            {
                if (movimentacoes.Count > 0)
                {
                    decimal somaDebitos = 0;
                    decimal somaCreditos = 0;
                    foreach (Movimentacoes movimentacao in movimentacoes)
                    {
                        if (movimentacao.TipoMovimento == "C")
                        {
                            somaCreditos = somaCreditos + movimentacao.Valor;
                        }
                        else
                        {
                            somaDebitos = somaDebitos + movimentacao.Valor;

                        }

                    }
                    contaResponse = new SaldoContarResponse(movimentacoes[0].IdConta, usuarioAccount.NumberAccount, usuarioAccount.Name, DateTime.Now.ToString("DD/MM/YYYY"), (contaResponse.SaldoAtual = somaCreditos - somaDebitos));
                    
                }
            }
            return contaResponse;
        }

        private List<Movimentacoes> ObterMovimentacoes(string? idConta)
        {
            throw new NotImplementedException();
        }

        private UsuarioAccount ContaCorrenteCadastrada(string identificacaoContaCorrente)
        {
            IDataReader reader;
            UsuarioAccount usuario = null;
            // Lógica para verificar se a conta corrente está cadastrada
            using (IDbConnection connection = _Connection)
            {
                reader = connection.ExecuteReader("Select * from contacorrente where idcontacorrente = '" + identificacaoContaCorrente + "'");
                if (reader.Read())
                {
                    // Retorna true se estiver cadastrada, false caso contrário
                    // Monta os dados do usuario
                    return usuario;
                }
                else
                {
                    return usuario;
                }
            }
        }
    }
}
