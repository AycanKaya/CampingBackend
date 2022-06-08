using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain.Entities;
using Application.Interfaces;

namespace Application.Features.CardFeatures.Command
{

    //STRING TYPE RETURNED !!!!!!!!
    
    public class CreateCardCommand : IRequest<string>
    {
        public string CardNo { get; set; }
        public DateTime ExprationDate { get; set; }
        public int CardType { get; set; }
        public string UserId { get; set; }

        public class CreateCardHandler : IRequestHandler<CreateCardCommand , string>
        {
            private readonly IApplicationDbContext _context;
            public CreateCardHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(CreateCardCommand command,  CancellationToken cancellationToken)
            {
                var card = new Card();
                card.CardNo = command.CardNo;   
                card.CardType = command.CardType;
                card.UserId= command.UserId;
                card.ExprationDate = command.ExprationDate;
                _context.Cards.Add(card);
                await _context.SaveChanges();
                return card.CardNo;
            }
               
        }

    }
}
