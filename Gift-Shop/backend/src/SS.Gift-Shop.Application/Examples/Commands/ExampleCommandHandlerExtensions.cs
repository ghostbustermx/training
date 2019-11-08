using System;
using System.Threading.Tasks;
using SS.GiftShop.Core.Exceptions;
using SS.GiftShop.Core.Persistence;
using SS.GiftShop.Domain.Entities;
using SS.GiftShop.Domain.Model;

namespace SS.GiftShop.Application.Examples.Commands
{
    internal static class ExampleCommandHandlerExtensions
    {
        public static async Task ValidateUniqueEmail(IReadOnlyRepository readOnlyRepository, AddExampleModel request)
        {
            var query = readOnlyRepository.Query<Example>(x => x.Status == EnabledStatus.Enabled && x.Email == request.Email);
            var exists = await readOnlyRepository.AnyAsync(query);
            if (exists)
            {
                throw new ObjectValidationException(nameof(request.Email), $"Email {request.Email} is already assigned to an example.");
            }
        }

        public static async Task<Example> FindEnabledExample(this IRepositoryBase repository, Guid id)
        {
            var entity = await repository.SingleAsync<Example>(x => x.Id == id && x.Status == EnabledStatus.Enabled);
            if (entity == null)
            {
                throw EntityNotFoundException.For<Example>(id);
            }

            return entity;
        }
    }
}
