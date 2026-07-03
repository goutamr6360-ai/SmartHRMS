using SmartHRMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHRMS.Application.Interfaces.Repositories
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user, IList<String> roles);
    }
}
