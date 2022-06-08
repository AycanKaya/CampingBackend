using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CardFeatures.Queries
{
    public class GetCardQuery : IRequest<Card>
    {
        public string CardNo { get; set; }
        public class GetCardQueyHandler : IRequestHandler<GetCardQuery , Card>
        {
            private readonly IApplicationDbContext _context;
            public GetCardQueyHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Card> Handle(GetCardQuery request, CancellationToken cancellationToken)
            {
                var card= _context.Cards.Where(x => x.CardNo == request.CardNo).FirstOrDefault();
                if (card == null)
                {
                    return null;
                }
                return card;

            }
        }
    }
}
