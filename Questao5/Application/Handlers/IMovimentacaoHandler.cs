using Questao5.Domain.Entities;

namespace Questao5.Application.Handlers
{
    public interface IMovimentacaoHandler
    {
        MovimentacaoResponse Handle(MovimentacaoRequest request);
    }
}
