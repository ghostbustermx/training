using System.Collections.Generic;
using SS.GiftShop.Application.Commands;

namespace SS.GiftShop.Application.Examples.Commands.Add
{
    public class AddExamplesCommand : ICommand
    {
        public List<AddExampleModel> Examples { get; }

        public AddExamplesCommand(List<AddExampleModel> examples)
        {
            Examples = examples;
        }
    }
}
