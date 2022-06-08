using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Domain.Entities;
namespace Application.Features.BillFeatures.Commands
{
    public class CreateBillCommand : IRequest<int>
    {

        public int Id { get; set; }
        public int OrderId { get; set; }

        public class CreateBilllHandler : IRequestHandler<CreateBillCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateBilllHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateBillCommand command,CancellationToken cancellationToken)
            {
                var bill = new Bill();
                bill.OrderId = command.OrderId;
                bill.Id = command.Id;
                _context.Bills.Add(bill);
                await _context.SaveChanges();
                return command.Id;
                
            }


        }






    }
}
