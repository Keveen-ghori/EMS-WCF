using EMS.Application.Contracts.Repository.Employees;
using EMS.Application.DTO.Employee;
using EMS.Data.Models;
using EMS.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EMS.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementContext context;

        public EmployeeRepository(EmployeeManagementContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateNewEmp(Employee model)
        {
            var IsEmailExists = await this.context.Employees.FirstOrDefaultAsync(x => x.Email == model.Email);

            if (IsEmailExists != null)
            {
                return false;
            }

            Employee emp = new Employee();
            emp.FirstName = model.FirstName;
            emp.LastName = model.LastName;
            emp.Email = model.Email;
            emp.Attemps = 0;
            emp.TotalAttemps = 5;
            emp.Dob = model.Dob;
            emp.CreatedAt = DateTime.Now;
            emp.PasswordUpdatedAt = DateTime.Now;
            emp.ExpDays = 7;
            emp.Status = true;
            emp.IsLocked = false;
            emp.Password = Crypto.HashPassword(model.Password);
            emp.UserName = model.FirstName + " " + model.LastName;
            emp.Gender = model.Gender;
            await this.context.Employees.AddRangeAsync(emp);
            this.context.SaveChanges();
            return true;

        }

        public async Task<bool> DeleteEmpByid(Expression<Func<Employee, bool>> expression)
        {
            var isEmpExists = await this.context.Employees.FirstOrDefaultAsync(expression);
            if(isEmpExists == null)
            {
                return false;   
            }
            else
            {
                isEmpExists.DeletedAt = DateTime.Now;
                this.context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmp(Expression<Func<Employee, bool>> expression)
        {
            return await this.context.Set<Employee>().Where(expression).ToListAsync();
        }

        public async Task<Employee> GetEmpById(Expression<Func<Employee, bool>> expression)
        {
            return await this.context.Set<Employee>().FirstOrDefaultAsync(expression);
        }
    }
}
