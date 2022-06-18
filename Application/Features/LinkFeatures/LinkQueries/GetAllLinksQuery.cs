using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.LinkFeatures.LinkQueries
{
    public class GetAllLinksQuery :  IRequest<IEnumerable<Link>>
    {
        public class GetAllLinksQueryHandler : IRequestHandler<GetAllLinksQuery, IEnumerable<Link>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllLinksQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Link>> Handle(GetAllLinksQuery query, CancellationToken cancellationToken)
            {

                var links = await _context.Links.ToListAsync();
                if (links == null)
                {
                    return null;
                }

                return links.AsReadOnly();
            }
        }
    }
}
