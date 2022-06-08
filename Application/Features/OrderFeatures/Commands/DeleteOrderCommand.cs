using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.OrderFeatures.Commands
{
    public class DeleteOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, int>
        {
            private  readonly IApplicationDbContext _context;
            public DeleteOrderCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
            {
                var order = _context.Orders.Where(o => o.Id == command.Id).FirstOrDefault();
                if(order == null) { return default; }
                _context.Orders.Remove(order);
                await _context.SaveChanges();
                return command.Id;  


            }
        }
    }
}
