using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CampsiteFeatures.Queries
{
    public class GetCampsiteByLocation : IRequest<IEnumerable<Campsite>>
    {
        public string Location { get; set; }

        public class GetCampsiteByLocationHandler : IRequestHandler<GetCampsiteByLocation, IEnumerable<Campsite>>
        {
            private readonly IApplicationDbContext _context;
            public GetCampsiteByLocationHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Campsite>> Handle(GetCampsiteByLocation query, CancellationToken cancellationToken)
            {
                var call_list = query.Location.Split('-');

                
                List<Campsite> result = new List<Campsite>();

                foreach (var call in call_list)
                {
                    var list = _context.Campsites;
                    foreach (var camp in list)
                    {
                        string[] c = camp.Location.Split(",");

                        if (c !=  null &&  Array.IndexOf(c,call)  !=-1)
                        {
                            if (!result.Contains(camp))
                            {
                                result.Add(camp);
                            }
                            
                        }

                    }
                }



                if(result.Count  == 0)
                {
                    return null;
                }

                
                return result.AsReadOnly();
            }
        }
    }
}
