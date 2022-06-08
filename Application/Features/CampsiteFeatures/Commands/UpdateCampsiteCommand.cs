using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CampsiteFeatures.Commands
{
    public class UpdateCampsiteCommand : IRequest<int>
    {
        public string OwnerID { get; set; }
        public int VacationSpotID { get; set; }
        public int AdultPrice { get; set; }
        public int ChildPrice { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonCloseDate { get; set; }
        public class UpdateCampsiteHandler : IRequestHandler<UpdateCampsiteCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateCampsiteHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateCampsiteCommand command, CancellationToken cancellationToken)
            {
                var campsite = _context.Campsites.Where(a => a.VacationSpotID == command.VacationSpotID).FirstOrDefault();

                if (campsite == null)
                {
                    return default;
                }
                else
                {
                    campsite.SeasonStartDate = command.SeasonStartDate;
                    campsite.SeasonCloseDate= command.SeasonCloseDate;
                    campsite.AdultPrice =  command.AdultPrice;
                    campsite.ChildPrice = command.ChildPrice;
                    

                    await _context.SaveChanges();
                    return campsite.VacationSpotID;
                }
            }
        }
    }
}
