using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;
namespace Application.Features.BillFeatures.Commands
{
    public class UpdateBillCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        public class UpdateBillCommandHandler : IRequestHandler< UpdateBillCommand, int>
        {
            private  readonly IApplicationDbContext _context;
            public UpdateBillCommandHandler(IApplicationDbContext context) { _context = context; }
            public async Task<int> Handle( UpdateBillCommand command, CancellationToken cancellationToken)
            {
                var bill= _context.Bills.Where(b => b.OrderId == command.OrderId).FirstOrDefault();
                if(bill == null)
                {
                    return default;
                }
                bill.OrderId= command.OrderId;
                return bill.Id;

            }
        }

    }
}
