namespace Questao5.Domain.Entities
{
    public class MovimentacaoRequest
    {
        public string? IdRequisicao { get; set; }
        public int IdContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public string? TipoMovimento { get; set; }
    }
}
