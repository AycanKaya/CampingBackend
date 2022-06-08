using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.VacationSpotFeatures.Commands;
namespace Application.Features.CampsiteFeatures.Commands
{
    public class DeleteCampsiteCommand : IRequest<int>
    {
        public int VacationSpotID { get; set; }
        public class DeleteCampsiteCommandHandler : IRequestHandler<DeleteCampsiteCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCampsiteCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteCampsiteCommand command, CancellationToken cancellationToken)
            {
                //Every vacationspot has a campsite. There is one-to-one relationship. 
                var campsite = await _context.Campsites.Where(a => a.VacationSpotID == command.VacationSpotID).FirstOrDefaultAsync();
                if (campsite == null) return default;
                _context.Campsites.Remove(campsite);

                var vacation = await _context.Vacations.Where(a => a.Id == command.VacationSpotID).FirstOrDefaultAsync();
                if (vacation == null) return default;
                _context.Vacations.Remove(vacation);


                await _context.SaveChanges();
                //return will be changed
                return campsite.VacationSpotID;
            }
        }
    }
}