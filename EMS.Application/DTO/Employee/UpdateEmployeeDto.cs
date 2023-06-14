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
    public class UpdateEmployeeDto : IExtensibleDataObject
    {
        [DataMember]
        public string firstName { get; set; } = string.Empty;
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        [DataType(DataType.Date)]
        public DateTime dOB { get; set; }
        [DataMember]
        public byte gender { get; set; } = 1;
        [DataMember]
        public bool status { get; set; }
        [DataMember]
        public bool isLocked { get; set; }
        [DataMember]
        public DateTime? updated_At { get; set; } = DateTime.Now;
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
