using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CardFeatures.Command
{
    public class DeleteCardCommand : IRequest<string>
    { 
        public string CardNo { get; set; }
        public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand,string>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCardCommandHandler(IApplicationDbContext context)
            {
                    _context = context;
            }
            public async Task<string> Handle(DeleteCardCommand command , CancellationToken cancellationToken)
            {
                var card = await _context.Cards.Where(a => a.CardNo == command.CardNo).FirstOrDefaultAsync();
                if(card == null)
                {
                    return null;
                }
                else
                {
                    _context.Cards.Remove(card);
                    await _context.SaveChanges();
                    return card.CardNo;

                }
            }
        }
            
            
            
    }
}
