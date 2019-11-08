using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SS.GiftShop.Application.Commands;
using SS.GiftShop.Core.Persistence;
using SS.GiftShop.Domain.Entities;

namespace SS.GiftShop.Application.Examples.Commands.Add
{
    public sealed class AddExamplesCommandHandler : CommandHandler<AddExamplesCommand>
    {
        private readonly IRepository _repository;
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;

        public AddExamplesCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _readOnlyRepository = repository.AsReadOnly();
            _mapper = mapper;
        }

        protected override async Task Handle(AddExamplesCommand request, CancellationToken cancellationToken)
        {
            foreach (var exampleModel in request.Examples)
            {
                var entity = _mapper.Map<Example>(exampleModel);

                _repository.Add(entity);
            }

            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}
