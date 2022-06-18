using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CampsiteFeatures.Queries
{
    public class GetCampsiteQuery : IRequest<Campsite>
    {

        public int VacationSpotID { get; set; }

        public class GetCampsiteQueryHandler : IRequestHandler<GetCampsiteQuery, Campsite>
        {
            private readonly IApplicationDbContext _context;
            public GetCampsiteQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Campsite> Handle(GetCampsiteQuery query, CancellationToken cancellationToken)
            {
                var campsite = _context.Campsites.Where(a => a.VacationSpotID == query.VacationSpotID).FirstOrDefault();
                if (campsite == null) return null;
                
                return campsite;
            }
        }
    }
}