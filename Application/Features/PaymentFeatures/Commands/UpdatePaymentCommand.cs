using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;


namespace Application.Features.PaymentFeatures.Commands
{
    public class UpdatePaymentCommand :IRequest<int>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int TotalPrice { get; set; }
        public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdatePaymentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdatePaymentCommand command, CancellationToken cancellationToken)
            {
                var payment = _context.Payments.Where(x => x.OrderId == command.OrderId).FirstOrDefault();
                if (payment == null) { return default; }
                payment.TotalPrice = command.TotalPrice;
                payment.OrderId = command.OrderId;
                await _context.SaveChanges();
                return payment.OrderId;
            }
        }

    }
}
