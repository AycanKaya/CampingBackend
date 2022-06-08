using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.OrderFeatures.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {
        public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery,  IEnumerable<Order>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllOrdersQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery getAllOrdersQuery, CancellationToken cancellationToken)
            {
                var orderList = await _context.Orders.ToListAsync();
                if(orderList == null) { return default; }
                return orderList.AsReadOnly();
            }
        }
    }
}
