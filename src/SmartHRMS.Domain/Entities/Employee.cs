using SmartHRMS.Domain.Common;
using SmartHRMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHRMS.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeCode { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }

        public DateOnly JoiningDate { get; set; }

        public Gender Gender { get; set; }

        public EmploymentStatus EmploymentStatus { get; set; }

        public Guid CompanyId { get; set; }

        public Guid DepartmentId { get; set; }

        public Guid DesignationId { get; set; }
    }
}
