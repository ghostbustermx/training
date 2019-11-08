using SS.GiftShop.Domain.Model;

namespace SS.GiftShop.Application.Examples.Commands
{
    public class AddExampleModel: IStatus<EnabledStatus>
    {
        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public string Email { get; set; }

        public EnabledStatus Status { get; set; }
    }
}
