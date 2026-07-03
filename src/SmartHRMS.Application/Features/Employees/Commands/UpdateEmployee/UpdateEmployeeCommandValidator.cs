using MediatR;
using SmartHRMS.Application.Exceptions;
using SmartHRMS.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHRMS.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : IRequestHandler<UpdateEmployeeCommand,Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Guid> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if(employee == null)
                throw new NotFoundException($"Employee with Id '{request.Id}' not found.");
            employee.EmployeeCode = request.EmployeeCode;
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;

            await _employeeRepository.UpdateAsync(employee);

            return employee.Id;
        }
    }
}
