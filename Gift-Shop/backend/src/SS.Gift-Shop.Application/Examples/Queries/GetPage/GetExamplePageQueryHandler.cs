using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SS.GiftShop.Application.Infrastructure;
using SS.GiftShop.Application.Queries;
using SS.GiftShop.Core.Persistence;
using SS.GiftShop.Domain.Entities;
using SS.GiftShop.Domain.Model;

namespace SS.GiftShop.Application.Examples.Queries.GetPage
{
    public sealed class GetExamplePageQueryHandler : IQueryHandler<GetExamplePageQuery, PaginatedResult<ExampleModel>>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IPaginator _paginator;

        public GetExamplePageQueryHandler(IReadOnlyRepository readOnlyRepository, IMapper mapper, IPaginator paginator)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
            _paginator = paginator;
        }

        public async Task<PaginatedResult<ExampleModel>> Handle(GetExamplePageQuery request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepository.Query<Example>(x => x.Status == EnabledStatus.Enabled);

            if (!string.IsNullOrEmpty(request.Term))
            {
                var term = request.Term.Trim();
                query = query.Where(x => x.Name.Contains(term));
            }

            var sortCriteria = request.GetSortCriteria();
            var items = query
                .ProjectTo<ExampleModel>(_mapper.ConfigurationProvider)
                .OrderByOrDefault(sortCriteria, x => x.Name);
            var page = await _paginator.MakePageAsync(_readOnlyRepository, query, items, request, cancellationToken);

            return page;
        }
    }
}
