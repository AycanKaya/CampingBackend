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
    public class UpdateOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int PlaceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumOfAdult { get; set; }
        public int NumOfChilder { get; set; }
        public bool isPaid { get; set; }
        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateOrderCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateOrderCommand command,CancellationToken cancellationToken)
            {
                var order = _context.Orders.Where(o => o.Id == command.Id).FirstOrDefault();
                if (order == null) { return default; }
                order.CustomerId = command.CustomerId;
                order.PlaceId = command.PlaceId;
                order.NumOfChilder = command.NumOfChilder;  
                order.isPaid = command.isPaid;
                order.NumOfAdult= command.NumOfAdult;
                order.StartDate = command.StartDate;
                order.EndDate = command.EndDate;
                await _context.SaveChanges();
                return order.Id; 
                


            }
        }
    }
}
