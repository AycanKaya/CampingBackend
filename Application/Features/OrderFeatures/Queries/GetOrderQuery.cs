using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderFeatures.Queries
{
    public class GetOrderQuery : IRequest<Order>
    {
        public int Id { get; set; }

        public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Order>
        {
            private readonly IApplicationDbContext _context;
            public GetOrderQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Order> Handle(GetOrderQuery command, CancellationToken cancellationToken)
            {
                var order = _context.Orders.Where(o => o.Id == command.Id).FirstOrDefault();
                if (order == null)
                {
                    return default;

                }
                return order;



            }
        }

    }
}
