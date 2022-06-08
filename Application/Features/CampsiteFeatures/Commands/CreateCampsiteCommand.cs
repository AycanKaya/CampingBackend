using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;


namespace Application.Features.CampsiteFeatures.Commands
{
    public class CreateCampsiteCommand : IRequest<int>
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public string Location { get; set; }

        public int HolidayDestinationID { get; set; }
        public float Rate { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Link> Links { get; set; }

        public string OwnerID { get; set; }
        public int VacationSpotID { get; set; }

        public int AdultPrice { get; set; }
        public int ChildPrice { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonCloseDate { get; set; }


        public class CreateCampsiteHandler : IRequestHandler<CreateCampsiteCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateCampsiteHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCampsiteCommand request, CancellationToken cancellationToken)
            {
                var campsite = new Campsite();
                campsite.Comments = request.Comments;
                campsite.Name = request.Name;
                campsite.Description = request.Description;
                campsite.Location = request.Location;
                campsite.HolidayDestinationID = request.HolidayDestinationID;
                campsite.Rate= request.Rate;
                campsite.lng = request.lng;
                campsite.lat = request.lat;
              //  campsite.Links = request.Links;
                foreach(var link in request.Links)
                {
                    campsite.Links.Add(link);
                }

                campsite.OwnerID = request.OwnerID;
                campsite.VacationSpotID = request.VacationSpotID;
                campsite.ChildPrice = request.ChildPrice;
                campsite.AdultPrice= request.AdultPrice;
                campsite.SeasonStartDate = request.SeasonStartDate;
                campsite.SeasonCloseDate = request.SeasonCloseDate;
                _context.Campsites.Add(campsite);
                await _context.SaveChanges();
                return campsite.VacationSpotID;


            }
        }
    }
}
