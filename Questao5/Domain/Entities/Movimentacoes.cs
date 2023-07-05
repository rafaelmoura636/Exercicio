using Castle.DynamicProxy;

namespace Questao5.Domain.Entities
{
    public class Movimentacoes
    {
        public string? IdMovimento { get; set; }
        public string? IdConta { get; set; }
        public string? DataMovimento { get; set; }
        public string? TipoMovimento { get; set; }
        public decimal Valor { get; set; }

        public Movimentacoes(string IdMov, string IdCon, string Data, string TipoMov, decimal Val)
        {
            IdMovimento = IdMov;
            IdConta = IdCon;
            DataMovimento = Data;
            TipoMovimento = TipoMov;
            Valor = Val;
        }
    }
}
