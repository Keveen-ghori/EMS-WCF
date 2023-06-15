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
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EMS.Web
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
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

        public async Task<ApiResponse<EmployeeSummaryDto>> GetEmployeeByIdWebService(string EmployeeId)
        {
            try
            {
                ApiResponse<EmployeeSummaryDto> apiResponse = new ApiResponse<EmployeeSummaryDto>();
                EmployeeService employeeService = new EmployeeService(this.employeeRepository);

                EmployeeSummaryDto employees = await employeeService.GetEMployeeById(EmployeeId);
                apiResponse.Content = employees;
                apiResponse.Success = true;
                apiResponse.StatusCode = HttpStatusCode.OK;

                return apiResponse;
            }

            catch (Exception ex)
            {
                ApiResponse<EmployeeSummaryDto> apiResponse = new ApiResponse<EmployeeSummaryDto>();
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

        public async Task<ApiResponse<bool>> DeleteEmployeeByidWebService(string EmployeeId)
        {
            try
            {
                ApiResponse<bool> apiResponse = new ApiResponse<bool>();
                EmployeeService employeeService = new EmployeeService(this.employeeRepository);

                bool employees = await employeeService.DeleteEmp(EmployeeId);
                apiResponse.Content = employees;
                apiResponse.Success = true;
                apiResponse.StatusCode = HttpStatusCode.OK;

                return apiResponse;
            }
            catch (Exception ex)
            {
                ApiResponse<bool> apiResponse = new ApiResponse<bool>();
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

        public async Task<ApiResponse<bool>> CreateEmployeeWebService(CreateEmployeeDto model)
        {
            try
            {
                ApiResponse<bool> apiResponse = new ApiResponse<bool>();
                EmployeeService employeeService = new EmployeeService(this.employeeRepository);

                bool employees = await employeeService.CreateEmp(model);
                apiResponse.Content = employees;
                apiResponse.Success = true;
                apiResponse.StatusCode = HttpStatusCode.OK;

                return apiResponse;
            }
            catch (Exception ex)
            {
                ApiResponse<bool> apiResponse = new ApiResponse<bool>();
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

        public async Task<ApiResponse<bool>> UpdateEMployeeWebService(UpdateEmployeeDto model, string Employeeid)
        {
            try
            {
                ApiResponse<bool> apiResponse = new ApiResponse<bool>();
                EmployeeService employeeService = new EmployeeService(this.employeeRepository);


                var Id = Convert.ToInt64(Employeeid);
                bool employees = await employeeService.UpdateEmp(model, Id);
                apiResponse.Content = employees;
                apiResponse.Success = true;
                apiResponse.StatusCode = HttpStatusCode.OK;

                return apiResponse;
            }
            catch (Exception ex)
            {
                ApiResponse<bool> apiResponse = new ApiResponse<bool>();
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
