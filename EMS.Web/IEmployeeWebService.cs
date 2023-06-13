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

        [OperationContract]
        Task<ApiResponse<IEnumerable<EmployeeSummaryDto>>> GetEmployees();
    }
}
