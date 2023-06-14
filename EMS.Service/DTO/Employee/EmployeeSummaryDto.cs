using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.DTO.Employee
{
    [DataContract]
    public class EmployeeSummaryDto : IExtensibleDataObject
    {
        [DataMember]
        public long EmployeeId { get; set; }
        [DataMember]
        public string UserName { get; set; } = string.Empty;
        [DataMember]
        public string Email { get; set; } = string.Empty;
        [DataMember]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        [DataMember]
        public byte Gender { get; set; }
        [DataMember]
        public int Attemps { get; set; }
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public bool IsLocked { get; set; }

        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
