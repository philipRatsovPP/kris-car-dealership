
using Dealership.Core.Contracts;
using System.Collections.Generic;

namespace Dealership.Commands
{
    public class ShowUsersCommand : BaseCommand
    {
        public ShowUsersCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override bool RequireLogin => throw new System.NotImplementedException();

        protected override string ExecuteCommand()
        {
            throw new System.NotImplementedException();
        }
    }
}
