using Questao5.Domain.Entities;

namespace Questao5.Application.Handlers
{
    public interface ISaldoContaHandle
    {
        SaldoContarResponse Handle(SaldoContaRequest request);
    }
}
