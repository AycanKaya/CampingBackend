using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.VacationSpotFeatures.Queries
{
    public class GetAllVacationSpotQuery : IRequest<IEnumerable<VacationSpot>>
    {

        public class GetAllVacationSpotQueryHandler : IRequestHandler<GetAllVacationSpotQuery, IEnumerable<VacationSpot>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllVacationSpotQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<VacationSpot>> Handle(GetAllVacationSpotQuery query, CancellationToken cancellationToken)
            {
                var vacations = await _context.Vacations.ToListAsync();
                if (vacations == null)
                {
                    return null;
                }
                return vacations.AsReadOnly();
            }
        }
    }
}
