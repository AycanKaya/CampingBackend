using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.VacationSpotFeatures.Commands
{
    public class DeleteVacationSpotCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteVacationSpotCommandHandler : IRequestHandler<DeleteVacationSpotCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteVacationSpotCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteVacationSpotCommand command, CancellationToken cancellationToken)
            {
                var vacation = await _context.Vacations.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (vacation == null) return default;
                _context.Vacations.Remove(vacation);
                await _context.SaveChanges();

                var campsite = await _context.Campsites.Where(a => a.VacationSpotID == command.Id).FirstOrDefaultAsync();
                if (campsite == null) return default;
                _context.Campsites.Remove(campsite);
                await _context.SaveChanges();

                return vacation.Id;
            }
        }
    }
}
