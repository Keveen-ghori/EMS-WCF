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
        private EmployeeManagementContext context;
        private EmployeeRepository employeeRepository;
        private IMapper mapper;

        [TestInitialize]
        public void Initialize()
        {
            context = new EmployeeManagementContext();
            employeeRepository = new EmployeeRepository(context);

            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            mapper = configuration.CreateMapper();
        }

        [TestMethod]
        public async Task TestGetAllEmp()
        {
            var emp = await employeeRepository.GetAllEmp(x => x.DeletedAt == null);
            var empSummaryDtos = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeSummaryDto>>(emp);

            // Assert
            Assert.IsNotNull(empSummaryDtos);
            Assert.IsTrue(empSummaryDtos.Any());
        }

        [TestMethod]
        public async Task TestGetEmpById()
        {
            long employeeId = 53;

            var emp = await employeeRepository.GetEmpById(x => x.EmployeeId == employeeId && x.DeletedAt == null);
            var empSummaryDto = mapper.Map<Employee, EmployeeSummaryDto>(emp);

            // Assert
            Assert.IsNotNull(empSummaryDto);
            Assert.IsTrue(empSummaryDto.EmployeeId != 0);
        }


        [TestCleanup]
        public void Cleanup()
        {
            context.Dispose();
        }
    }
}
