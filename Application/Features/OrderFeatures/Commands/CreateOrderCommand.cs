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
    public class CreateOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int PlaceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumOfAdult { get; set; }
        public int NumOfChilder { get; set; }
        public bool isPaid { get; set; }
        public  class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateOrderCommandHandler(IApplicationDbContext context)
            {
                    _context = context;
            }
            public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
            {
                var order = new Order();
                order.CustomerId = command.CustomerId;
                order.NumOfChilder= command.NumOfChilder;
                order.NumOfAdult = command.NumOfAdult;
                order.StartDate = command.StartDate;
                order.EndDate = command.EndDate;
                order.PlaceId = command.PlaceId;
                order.isPaid= command.isPaid;
                
                _context.Orders.Add(order);
                await _context.SaveChanges();
                return order.Id;


            }
        }
    }
}
