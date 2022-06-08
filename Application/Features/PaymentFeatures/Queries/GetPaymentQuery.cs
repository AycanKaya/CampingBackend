using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.PaymentFeatures.Queries
{
    public class GetPaymentQuery :IRequest<Payment>
    {
        public int Id { get; set; }
        public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, Payment>
        {
            private readonly IApplicationDbContext _context;
            public GetPaymentQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Payment> Handle(GetPaymentQuery request,CancellationToken cancellationToken)
            {
                var payment =  _context.Payments.Where(x => x.Id == request.Id).FirstOrDefault();
                if (payment == null) { return null; }
                return payment;

            }
        }
    }
}
