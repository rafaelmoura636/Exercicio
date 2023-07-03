namespace Questao5.Domain.Entities
{
    public class MovimentacaoResponse
    {
        public int IdMovimento { get; set; }

        public MovimentacaoResponse(int idMovimento)
        {
            IdMovimento = idMovimento;
        }
    }
}
