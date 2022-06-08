using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.VacationSpotFeatures.Commands
{
    public class CreateVacationSpotCommand : IRequest<int>
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Capacity { get; set; }
        public bool isValid { get; set; }



        public class CreateVacationSpotHandler : IRequestHandler<CreateVacationSpotCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateVacationSpotHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateVacationSpotCommand request, CancellationToken cancellationToken)
            {
                var vacation = new VacationSpot();
                vacation.Address = request.Address;
                vacation.Email = request.Email; 
                vacation.Phone = request.Phone; 
                vacation.Capacity = request.Capacity;   
                vacation.isValid = true; 
                _context.Vacations.Add(vacation);
                await _context.SaveChanges();
                return vacation.Id;


            }
        }





    }
}
