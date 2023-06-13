using EMS.Application.Contracts.Repository.Employees;
using EMS.Data.Models;
using EMS.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementContext context;

        public EmployeeRepository(EmployeeManagementContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllEmp(Expression<Func<Employee, bool>> expression)
        {
            return await this.context.Set<Employee>().ToListAsync();
        }

        public async Task<Employee> GetEmpById(Expression<Func<Employee, bool>> expression)
        {
            return await this.context.Set<Employee>().FirstOrDefaultAsync(expression);
        }
    }
}
