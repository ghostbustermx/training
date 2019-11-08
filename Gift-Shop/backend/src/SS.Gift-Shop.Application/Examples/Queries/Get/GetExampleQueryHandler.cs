using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SS.GiftShop.Application.Queries;
using SS.GiftShop.Core.Exceptions;
using SS.GiftShop.Core.Persistence;
using SS.GiftShop.Domain.Entities;
using SS.GiftShop.Domain.Model;

namespace SS.GiftShop.Application.Examples.Queries.Get
{
    public sealed class GetExampleQueryHandler : IQueryHandler<GetExampleQuery, ExampleModel>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;

        public GetExampleQueryHandler(IReadOnlyRepository readOnlyRepository, IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
        }

        public async Task<ExampleModel> Handle(GetExampleQuery request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepository.Query<Example>(x => x.Id == request.Id && x.Status == EnabledStatus.Enabled)
                .ProjectTo<ExampleModel>(_mapper.ConfigurationProvider);

            var result = await _readOnlyRepository.SingleAsync(query, cancellationToken);

            if (result == null)
            {
                throw EntityNotFoundException.For<Example>(request.Id);
            }

            return result;
        }
    }
}
