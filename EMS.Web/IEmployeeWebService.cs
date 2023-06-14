using EMS.Application.DTO.Employee;
using EMS.Infrastructure.Api.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Web
{
    [ServiceContract]
    public interface IEmployeeWebService
    {
        [WebGet(UriTemplate = "Employees")]
        [OperationContract]
        Task<ApiResponse<IEnumerable<EmployeeSummaryDto>>> GetEmployees();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Employee/{EmployeeId}")]
        Task<ApiResponse<EmployeeSummaryDto>> GetEmployeeByIdWebService(string EmployeeId);

        [OperationContract]
        Task<ApiResponse<bool>> DeleteEmployeeByidWebService(long EmployeeId);
        [OperationContract]
        Task<ApiResponse<bool>> CreateEmployeeWebService(CreateEmployeeDto model);
    }
}
