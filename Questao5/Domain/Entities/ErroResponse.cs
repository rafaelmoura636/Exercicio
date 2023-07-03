namespace Questao5.Domain.Entities
{
    public class ErroResponse
    {
        public string Mensagem { get; set; }
        public string Tipo { get; set; }

        public ErroResponse(string mensagem, string tipo)
        {
            Mensagem = mensagem;
            Tipo = tipo;
        }
    }
}
