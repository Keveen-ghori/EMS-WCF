using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Data.Models;
using EMS.Infrastructure.Repository;
using EMS.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using EMS.Application.Mapper;
using EMS.Application.DTO.Employee;
using AutoMapper;

namespace EMS.Test
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        [TestMethod]
        public async Task GetEmpLists()
        {
            long EmployeeId = 53;
            using (EmployeeManagementContext context = new EmployeeManagementContext())
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(context);
                MapperConfiguration configuration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfile>();
                });

                IMapper mapper = configuration.CreateMapper();

                var emp = await employeeRepository.GetAllEmp(x => x.DeletedAt == null);
                var empSummaryDtos = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeSummaryDto>>(emp);
                Assert.IsNotNull(empSummaryDtos);
                Assert.IsTrue(empSummaryDtos.Any());

                var empbyId = await employeeRepository.GetEmpById(x => x.EmployeeId == EmployeeId && x.DeletedAt == null);
                var empSummaryDtosId = mapper.Map<Employee, EmployeeSummaryDto>(empbyId);
                Assert.IsNotNull(empSummaryDtosId);
                Assert.IsTrue(empSummaryDtosId.EmployeeId != 0);

            }
        }

        //[TestMethod]
        //public async Task<EmployeeSummaryDto> GetEmpById()
        //{
        //    long EmployeeId = 1;
        //    using (EmployeeManagementContext context = new EmployeeManagementContext())
        //    {
        //        EmployeeRepository employeeRepository = new EmployeeRepository(context);
        //        MapperConfiguration configuration = new MapperConfiguration(cfg =>
        //        {
        //            cfg.AddProfile<MappingProfile>();
        //        });

        //        IMapper mapper = configuration.CreateMapper();

        //        var emp = await employeeRepository.GetEmpById(x => x.EmployeeId == EmployeeId && x.DeletedAt == null);
        //        var empSummaryDtos = mapper.Map<Employee, EmployeeSummaryDto>(emp);
        //        Assert.IsNotNull(empSummaryDtos);
        //        Assert.IsTrue(empSummaryDtos.EmployeeId != 0);
        //        return empSummaryDtos;

        //    }
        //}
    }
}
