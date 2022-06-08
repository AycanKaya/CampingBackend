using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PaymentFeatures.Queries
{
    public class GetAllPaymentQuery :IRequest<IEnumerable<Payment>>
    {
        public class GetAllPaymentQueryHandler : IRequestHandler<GetAllPaymentQuery, IEnumerable<Payment>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllPaymentQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Payment>> Handle(GetAllPaymentQuery getAllPaymentQuery,CancellationToken cancellationToken)
            {
                var paymentList = await _context.Payments.ToListAsync(); 
                if(paymentList == null) { return default; }
                return paymentList.AsReadOnly();
            }
        }
    }
}
