using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Template.Core.Domain
{
    public class CoreRequest: IRequest<string[]>{
        
    }

    public class CoreHandler: IRequestHandler<CoreRequest, string[]>
    {
        public CoreHandler()
        {
        }

        public async Task<string[]> Handle(CoreRequest message, CancellationToken cancellationToken)
        {
            return new[] { "Test One", "Test Two" };
        }
    }
}
