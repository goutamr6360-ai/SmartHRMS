using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHRMS.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<Guid>
    {
        public DeleteEmployeeCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
