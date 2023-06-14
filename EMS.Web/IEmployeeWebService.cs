using EMS.Application.DTO.Employee;
using EMS.Infrastructure.Api.ApiModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace EMS.Web
{
    [ServiceContract]
    public interface IEmployeeWebService
    {

        [OperationContract]
        [WebGet(UriTemplate = "Employees", ResponseFormat = WebMessageFormat.Json)]
        Task<ApiResponse<IEnumerable<EmployeeSummaryDto>>> GetEmployees();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Employee/{EmployeeId}",
                ResponseFormat = WebMessageFormat.Json)]
        Task<ApiResponse<EmployeeSummaryDto>> GetEmployeeByIdWebService(string EmployeeId);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "EmployeeDelete/{EmployeeId}")]
        Task<ApiResponse<bool>> DeleteEmployeeByidWebService(string EmployeeId);

        /// <summary>
        /// Create EMployee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
                UriTemplate = "CreateEmployee",
                ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        Task<ApiResponse<bool>> CreateEmployeeWebService(CreateEmployeeDto model);

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Employeeid"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "PUT",
                UriTemplate = "UpdateEmployee/{Employeeid}",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
        Task<ApiResponse<bool>> UpdateEMployeeWebService(UpdateEmployeeDto model, string Employeeid);
    }
}
