using System.Net;

namespace Questao5.Domain.Entities
{
    public class SaldoContarResponse
    {
        public string? IdConta { get; set; }
        public int NumeroConta { get; set; }
        public string? NomeTitular { get; set; }
        public string? DataConsulta { get; set; }
        public decimal SaldoAtual { get; set; }

        public HttpStatusCode httpStatusCode { get; set; }
        public ErroResponse? ErroResponse { get; set; }
        public SaldoContarResponse(HttpStatusCode statusCode, ErroResponse erro)
        {
            httpStatusCode = statusCode;
            ErroResponse = erro;
        }
        public SaldoContarResponse(string IdConta,int NumConta,string NomTitular, string date,decimal Saldo)
        {
            this.IdConta = IdConta;
            NumeroConta = NumConta;
            NomeTitular = NomTitular;
            DataConsulta = date;
            SaldoAtual = Saldo;
        }
        public SaldoContarResponse()
        {
        }
    }
}
