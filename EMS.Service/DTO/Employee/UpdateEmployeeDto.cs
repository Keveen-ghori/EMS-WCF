using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.DTO.Employee
{
    [DataContract]
    public class UpdateEmployeeDto : IExtensibleDataObject
    {
        [DataMember]
        public string FirstName { get; set; } = string.Empty;
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public DateTime? DOB { get; set; }
        [DataMember]
        public byte Gender { get; set; } = 1;
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public bool IsLocked { get; set; }
        [DataMember]
        public DateTime? Updated_At { get; set; } = DateTime.Now;
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
