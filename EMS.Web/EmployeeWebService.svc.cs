using AutoMapper;
using EMS.Application.DTO.Employee;
using EMS.Application.Mapper;
using EMS.Data.Models;
using EMS.Infrastructure.Api.ApiModels;
using EMS.Infrastructure.Repository;
using EMS.Infrastructure.Services.EmployeeServices;
using EMS.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Web
{
    [ServiceBehavior]
    public class EmployeeWebService : IEmployeeWebService
    {
        #region Fields

        private EmployeeManagementContext context;
        private EmployeeRepository employeeRepository;
        private IMapper mapper;

        #endregion

        #region props

        readonly MapperConfiguration configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        #endregion

        #region Ctors

        public EmployeeWebService()
        {
            context = new EmployeeManagementContext();
            employeeRepository = new EmployeeRepository(context);
            mapper = configuration.CreateMapper();
        }


        #endregion

        #region Method


        public async Task<ApiResponse<IEnumerable<EmployeeSummaryDto>>> GetEmployees()
        {
            try
            {
                ApiResponse<IEnumerable<EmployeeSummaryDto>> apiResponse = new ApiResponse<IEnumerable<EmployeeSummaryDto>>();
                EmployeeService employeeService = new EmployeeService(this.employeeRepository);

                IEnumerable<Employee> employees = await employeeService.GetAllEmployees();
                var empMapped = this.mapper.Map<IEnumerable<EmployeeSummaryDto>>(employees);   
                apiResponse.Content = empMapped;
                apiResponse.Success = true;
                apiResponse.StatusCode = HttpStatusCode.OK;

                return apiResponse;
            }
            catch (Exception ex)
            {
                ApiResponse<IEnumerable<EmployeeSummaryDto>> apiResponse = new ApiResponse<IEnumerable<EmployeeSummaryDto>>();
                apiResponse.Success = false;
                apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                apiResponse.Messages = new List<ApiMessage>
                            {
                                new ApiMessage
                                {
                                    MessageType = ApiMessage.MessageTypes.EXCEPTION,
                                    Message = ex.Message
                                }
                            };

                return apiResponse;
            }

        }

        #endregion
    }
}
