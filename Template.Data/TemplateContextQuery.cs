using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Template.Core.Domain
{
    public class TemplateContextQuery : IRequest<TemplateContext> { }
    public class TemplateContextQueryHandler :
        IRequestHandler<TemplateContextQuery, TemplateContext>
    {
        public IMediator Mediator { get; }

        public TemplateContextQueryHandler(IMediator mediator)
        {
            Mediator = mediator;
        }

        public async Task<TemplateContext> Handle(TemplateContextQuery request, CancellationToken cancellationToken)
        {
            var users = await Mediator.Send(new Data.UsersQuery());

            var userEntities = users.Select(x => new Entities.User(x.FirstName, x.LastName, x.UsersId))
                                    .ToArray();

            return new TemplateContext(Mediator, userEntities);
        }
    }
}
