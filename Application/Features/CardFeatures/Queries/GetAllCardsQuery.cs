using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CardFeatures.Queries
{
    public class GetAllCardsQuery : IRequest<IEnumerable<Card>>
    {
        public class GetAllCardsQueryHandler : IRequestHandler<GetAllCardsQuery , IEnumerable<Card>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCardsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Card>> Handle(GetAllCardsQuery request, CancellationToken cancellationToken)
            {
                var cardList =  await _context.Cards.ToListAsync();
                if (cardList == null)
                {
                    return null;
                }
                return cardList.AsReadOnly();
            }
        }
    }
}
