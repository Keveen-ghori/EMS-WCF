using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Contracts.Repository.Employees
{
    public interface IAdminRepository
    {
        Task<bool> isAdminExists(string Email);
    }
}
