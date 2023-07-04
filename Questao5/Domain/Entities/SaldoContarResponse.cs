using System.Net;

namespace Questao5.Domain.Entities
{
    public class SaldoContarResponse
    {
        public string? IdConta { get; set; }
        public int NumeroConta { get; set; }
        public string NumeTitular { get; set; }
        public DateTime DataConsulta { get; set; }
        public decimal SaltoAtual { get; set; }

        public HttpStatusCode httpStatusCode { get; set; }
        public ErroResponse? ErroResponse { get; set; }
        public SaldoContarResponse(HttpStatusCode statusCode, ErroResponse erro)
        {
            httpStatusCode = statusCode;
            ErroResponse = erro;
        }
        public SaldoContarResponse(string IdMovimento)
        {
        }
    }
}
