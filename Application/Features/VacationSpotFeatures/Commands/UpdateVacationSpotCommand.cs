using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VacationSpotFeatures.Commands
{
    public class UpdateVacationSpotCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Capacity { get; set; }
        public bool isValid { get; set; }
        
        public class UpdateVacationSpotHandler : IRequestHandler<UpdateVacationSpotCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateVacationSpotHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateVacationSpotCommand command, CancellationToken cancellationToken)
            {
                var vacation = _context.Vacations.Where(a => a.Id == command.Id).FirstOrDefault();

                if (vacation == null)
                {
                    return default;
                }
                else
                {
                    vacation.Address = command.Address;
                    vacation.Email = command.Email;
                    vacation.Phone = command.Phone;
                    vacation.Capacity = command.Capacity;
                    vacation.isValid = command.isValid;
                                     
                    await _context.SaveChanges();
                    return vacation.Id;
                }
            }
        }
    }
}
