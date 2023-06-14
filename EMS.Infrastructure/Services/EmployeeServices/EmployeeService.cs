using AutoMapper;
using EMS.Application.Contracts.Repository.Employees;
using EMS.Application.DTO.Employee;
using EMS.Application.Mapper;
using EMS.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<EmployeeSummaryDto> GetEMployeeById(string EmployeeId)
        {
            var Id = Convert.ToInt64(EmployeeId);
            var emp = await this.employeeRepository.GetEmpById(x => x.EmployeeId == Id && x.DeletedAt == null);
            var empMapped = this.mapper.Map<EmployeeSummaryDto>(emp);
            return empMapped;
        }

        public async Task<bool> DeleteEmp(string EmployeeId)
        {
            var Id = Convert.ToInt64(EmployeeId);
            var status = await this.employeeRepository.DeleteEmpByid(x => x.EmployeeId == Id && x.DeletedAt == null);
            return status;
        }

        public async Task<bool> CreateEmp(CreateEmployeeDto model)
        {
            var isEmailExists = await this.employeeRepository.isEmailExists(model.Email);

            if(isEmailExists)
            {
                throw new InvalidOperationException("Email already exists. try with different account");
            }
            var modelMapped = this.mapper.Map<Employee>(model);
            await this.employeeRepository.CreateNewEmp(modelMapped);
            return true;
        }

        public async Task<bool> UpdateEmp(UpdateEmployeeDto model, long Employeeid)
        {
            var isEmpExists = await this.employeeRepository.GetEmpById(x => x.EmployeeId == Employeeid && x.DeletedAt == null);

            if (isEmpExists == null)
            {
                throw new InvalidOperationException("Employee not found.");
            }
            else
            {
                var modelMapped = this.mapper.Map<Employee>(model);
                await this.employeeRepository.UpdateEmp(modelMapped);

                return true;
            }
        }
        #endregion
    }
}
