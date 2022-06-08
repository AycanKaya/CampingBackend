using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;

namespace Application.Features.CardFeatures.Command
{
    public class UpdateCardCommand : IRequest<string>
    {
        public string CardNo { get; set; }
        public DateTime ExprationDate { get; set; }
        public int CardType { get; set; }
        public string UserId { get; set; }
        public class UpdateCardHandler : IRequestHandler<UpdateCardCommand, string>
        {
            private readonly IApplicationDbContext _context;
            public UpdateCardHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(UpdateCardCommand command, CancellationToken cancellationToken)
            {
                var card=_context.Cards.Where(x => x.CardNo==command.CardNo).FirstOrDefault();
                if (card == null) 
                { 
                    return default;
                }else
                {
                    card.ExprationDate = command.ExprationDate;
                    card.CardType = command.CardType;
                    card.UserId= command.UserId;
                    await _context.SaveChanges();
                    return card.CardNo;

                }
                


            }

        }
    }
}
