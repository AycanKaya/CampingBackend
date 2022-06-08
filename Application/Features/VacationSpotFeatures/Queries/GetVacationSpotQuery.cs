using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VacationSpotFeatures.Queries
{
    public class GetVacationSpotQuery : IRequest<VacationSpot>
    {
       
        public int Id { get; set; }

        public class GetVacationSpotQueryHandler : IRequestHandler<GetVacationSpotQuery, VacationSpot>
        {
            private readonly IApplicationDbContext _context;
            public GetVacationSpotQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<VacationSpot> Handle(GetVacationSpotQuery query, CancellationToken cancellationToken)
            {
                var vacation = _context.Vacations.Where(a => a.Id == query.Id).FirstOrDefault();
                if (vacation == null) return null;
                return vacation;
            }
        }
    }
}