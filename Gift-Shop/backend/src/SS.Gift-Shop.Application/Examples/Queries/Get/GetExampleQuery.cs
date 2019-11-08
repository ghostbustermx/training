using System;
using SS.GiftShop.Application.Queries;

namespace SS.GiftShop.Application.Examples.Queries.Get
{
    public class GetExampleQuery : IQuery<ExampleModel>
    {
        public Guid Id { get; }

        public GetExampleQuery(Guid id)
        {
            Id = id;
        }
    }
}
