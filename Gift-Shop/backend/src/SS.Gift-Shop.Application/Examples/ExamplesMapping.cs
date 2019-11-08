using AutoMapper;
using SS.GiftShop.Application.Examples.Commands;
using SS.GiftShop.Application.Examples.Queries;
using SS.GiftShop.Domain.Entities;

namespace SS.GiftShop.Application.Examples
{
    public sealed class ExamplesMapping : Profile
    {
        public ExamplesMapping()
        {
            CreateMap<AddExampleModel, Example>()
                .ForMember(x => x.Id, e => e.Ignore());

            CreateMap<Example, ExampleModel>();
        }
    }
}
