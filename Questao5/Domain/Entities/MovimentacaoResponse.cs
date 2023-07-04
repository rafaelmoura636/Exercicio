using System.Net;

namespace Questao5.Domain.Entities
{
    public class MovimentacaoResponse
    {
        public string? IdMovimento { get; set; }
        public HttpStatusCode httpStatusCode { get; set; }
        public ErroResponse? ErroResponse { get; set; }
        public MovimentacaoResponse(string IdMovimento, HttpStatusCode statusCode, ErroResponse erro)
        {
            this.IdMovimento = IdMovimento;
            httpStatusCode = statusCode;
            ErroResponse = erro;
        }
        public MovimentacaoResponse(string IdMovimento)
        {
            this.IdMovimento = IdMovimento;
        }
    }
}
