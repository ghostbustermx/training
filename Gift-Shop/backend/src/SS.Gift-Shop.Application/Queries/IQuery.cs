using MediatR;

namespace SS.GiftShop.Application.Queries
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}
