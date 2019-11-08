using System;

namespace SS.GiftShop.Application.Queries
{
    public class GetEntityQuery<T> : IQuery<T>
        where T : class
    {
        public Guid Id { get; set; }
    }
}
