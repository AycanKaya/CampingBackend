using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.BillFeatures.Queries
{
    public class GetBillQuery  : IRequest<Bill>
    {
        public int Id { get; set; }
        public class GetBillQueryHandler : IRequestHandler<GetBillQuery, Bill>
        {
            private readonly IApplicationDbContext _context;
            public GetBillQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Bill> Handle(GetBillQuery request, CancellationToken cancellationToken)
            {
                var bill = _context.Bills.Where(x => x.Id == request.Id).FirstOrDefault();
                if(bill == null) { return default; }
                return bill;
               

            }
        }

    }
}
