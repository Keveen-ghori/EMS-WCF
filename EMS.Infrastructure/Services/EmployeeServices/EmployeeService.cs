using AutoMapper;
using EMS.Application.Contracts.Repository.Employees;
using EMS.Application.DTO.Employee;
using EMS.Application.Mapper;
using EMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.Services.EmployeeServices
{
    public class EmployeeService
    {
        #region Fields

        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        #endregion

        #region Props
        readonly MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        #endregion

        #region Ctors

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = configuration.CreateMapper();
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var empLists = await this.employeeRepository.GetAllEmp(x => x.DeletedAt == null);

            return empLists;
        }

        #endregion
    }
}
