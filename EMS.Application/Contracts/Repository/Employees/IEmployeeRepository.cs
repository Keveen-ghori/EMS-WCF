using EMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Contracts.Repository.Employees
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmp(Expression<Func<Employee, bool>> expression);
        Task<Employee> GetEmpById(Expression<Func<Employee, bool>> expression);
    }
}
