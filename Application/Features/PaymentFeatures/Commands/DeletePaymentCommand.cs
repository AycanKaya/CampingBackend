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
    public class DeletePaymentCommand :IRequest<int>
    {
        public int Id { get; set; }
        public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeletePaymentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeletePaymentCommand command,  CancellationToken cancellationToken)
            {
                var payment = _context.Payments.Where(x => x.Id == command.Id).FirstOrDefault();
                if(payment == null) { return default; }
                _context.Payments.Remove(payment);
                await _context.SaveChanges();
                return command.Id;
            }
        }
    }
}
