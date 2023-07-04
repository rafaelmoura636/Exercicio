namespace Questao5.Domain.Entities
{
    public class MovimentacaoRequest
    {
        public int IdRequisicao { get; set; }
        public string? IdContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public string? TipoMovimento { get; set; }
    }
}
