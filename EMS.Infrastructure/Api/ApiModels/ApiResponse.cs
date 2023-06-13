using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace EMS.Infrastructure.Api.ApiModels
{
    [DataContract]
    public class ApiResponse<T>
    {
        [DataMember]
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        [DataMember]
        public List<ApiMessage> Messages { get; set; } = new List<ApiMessage>();
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public T Content { get; set; }
    }

    #region Message
    public class ApiMessage
    {
        public static class MessageTypes
        {
            public const string INFORMATION = "Information";
            public const string VALIDATION_ERROR = "Validation";
            public const string EXCEPTION = "Exception";
        }

        public string MessageType { get; set; }
        public string Message { get; set; }
    }

    #endregion

    #region Handle Exception
    public static class ApiMessageExtensions
    {
        public static ApiResponse<T> HandleException<T>(this ApiModels.ApiResponse<T> apiResponse, string exceptionMessage)
        {
            apiResponse.Success = false;
            apiResponse.StatusCode = HttpStatusCode.InternalServerError;
            apiResponse.Messages.Add(new ApiMessage()
            {
                MessageType = ApiModels.ApiMessage.MessageTypes.EXCEPTION,
                Message = exceptionMessage,
            });

            return apiResponse;
        }
        #endregion

        #region Handle Response
        public static ApiResponse<T> HandleResponse<T>(this ApiModels.ApiResponse<T> apiResponse, T responseContent)
        {
            var statusCode = (int)apiResponse.StatusCode;
            apiResponse.Success = statusCode <= 400; // if we aren't a 400s or 500s status code consider successful 
            //apiResponse.StatusCode = apiResponse.StatusCode;
            apiResponse.Content = responseContent;
            return apiResponse;
        }
        #endregion

        #region Handle Model State
        public static ApiResponse<T> HandleModelStateFailure<T>(this ApiResponse<T> apiResponse, ModelStateDictionary modelState)
        {
            var validationErrors = new List<ApiMessage>();

            foreach (var key in modelState.Keys)
            {
                var errors = modelState[key].Errors.Select(e => e.ErrorMessage);
                validationErrors.AddRange((IEnumerable<ApiMessage>)errors);
            }

            apiResponse.StatusCode = HttpStatusCode.BadRequest;
            apiResponse.Success = false;
            apiResponse.Messages = validationErrors;

            return apiResponse;
        }
        #endregion
    }
}