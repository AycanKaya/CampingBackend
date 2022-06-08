using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.PaymentFeatures.Commands
{
    public class CreatePaymentCommand : IRequest<int>
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int TotalPrice { get; set; }
        public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreatePaymentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
            {
                var payment  = new Payment();
                payment.OrderId = command.OrderId;
                payment.TotalPrice = command.TotalPrice;
                _context.Payments.Add(payment);
                //await _context.SaveChanges();
                return command.OrderId;


            }


        }
    }
}
