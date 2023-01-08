using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            public DataContext Context { get; }
            public Handler(DataContext context)
            {
               this.Context = context;
                
            }
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await Context.Activities.FindAsync(request.Id);
            }
        }
    }
}