using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHRMS.Application.Interfaces.Repositories;

namespace SmartHRMS.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeListDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeListDto>> Handle(GetAllEmployeesQuery request, 
            CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync();

            return employees.Select(employees => new EmployeeListDto
            {
                Id = employees.Id,
                EmployeeCode = employees.EmployeeCode,
                FirstName = employees.FirstName,
                LastName = employees.LastName,
                Email = employees.Email,
            }).ToList();
        }
    }
}
