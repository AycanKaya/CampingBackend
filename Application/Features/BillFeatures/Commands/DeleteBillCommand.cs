using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Features;
using Application.Interfaces;
using MediatR;
namespace Application.Features.BillFeatures.Commands
{
    public class DeleteBillCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteBillCommandHandler : IRequestHandler<DeleteBillCommand  , int>
        {
            private readonly IApplicationDbContext _context;    
            public DeleteBillCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteBillCommand command, CancellationToken cancellationToken)
            {
                var bill = _context.Bills.Where(x => x.Id == command.Id).FirstOrDefault();
                if(bill == null)
                {
                    return default;
                }
                _context.Bills.Remove(bill);
                await _context.SaveChanges();
                return command.Id;
            }
        }
    }
}
