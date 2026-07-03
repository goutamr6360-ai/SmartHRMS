using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHRMS.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandHandler()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Employee Id Required");
            RuleFor(x => x.EmployeeCode).NotEmpty().WithMessage("Employee code is required")
                .MaximumLength(20).WithMessage("Employee code must not exceed 20 character");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required")
                .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email is required.")
                    .EmailAddress().WithMessage("Email format is invalid.");
        }   
        
    }
}
