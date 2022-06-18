using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CampsiteFeatures.Queries
{
    public class GetAllCampsiteQuery : IRequest<IEnumerable<Campsite>>
    {

        public class GetAllCampsiteQueryHandler : IRequestHandler<GetAllCampsiteQuery, IEnumerable<Campsite>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCampsiteQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Campsite>> Handle(GetAllCampsiteQuery query, CancellationToken cancellationToken)
            {
                
                var campsites = await _context.Campsites.ToListAsync();
                if (campsites == null)
                {
                    return null;
                }

               

               
                return campsites.AsReadOnly();
            }
        }
    }
}
