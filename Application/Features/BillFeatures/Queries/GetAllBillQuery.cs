using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.BillFeatures.Queries
{
    public class GetAllBillQuery : IRequest<IEnumerable<Bill>>
    {

        public class GetAllBillQueryHandler : IRequestHandler<GetAllBillQuery, IEnumerable<Bill>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllBillQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Bill>> Handle(GetAllBillQuery request, CancellationToken cancellationToken)
            {
                var billList = await _context.Bills.ToListAsync();
                if (billList == null) { return null; }
                return billList.AsReadOnly();


            }



        }
    }
}
