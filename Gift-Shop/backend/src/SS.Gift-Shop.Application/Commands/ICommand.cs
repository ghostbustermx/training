using MediatR;

namespace SS.GiftShop.Application.Commands
{
    public interface ICommand<out T> : IRequest<T>
    {
    }

    public interface ICommand : ICommand<Unit>, IRequest
    {
    }
}
