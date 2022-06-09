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
    public class GetLinksByCampsite : IRequest<IEnumerable<Link>>
    {
        public int CampsiteVacationSpotID { get; set; }

        public class GetLinksByCampsiteHandler : IRequestHandler<GetLinksByCampsite, IEnumerable<Link>>
        {
            private readonly IApplicationDbContext _context;
        public GetLinksByCampsiteHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Link>> Handle(GetLinksByCampsite query, CancellationToken cancellationToken)
            {
                var links = await _context.Links.ToListAsync();
                if (links == null)
                {
                    return null;
                }
                var response = new List<Link>();
                foreach (var link in links)
                {
                    if(link.CampsiteVacationSpotID == query.CampsiteVacationSpotID)
                    {
                        response.Add(link);
                    }
                }


                return response.AsReadOnly();
            }
        }
    }
}
