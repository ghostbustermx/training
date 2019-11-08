using System.Collections.Generic;
using System.IO;
using MediatR;
using SS.GiftShop.Application.Commands;

namespace SS.GiftShop.Application.Infrastructure
{
    public interface IPictureCommand : IPictureCommand<Unit>
    {

    }

    public interface IPictureCommand<out TResponse> : ICommand<TResponse>
    {
        IEnumerable<IPictureModel> PictureModels { get; }
    }

    public interface IPictureModel
    {
        Stream PictureStream { get; }

        void SetPictureStream(Stream stream);
    }
}
