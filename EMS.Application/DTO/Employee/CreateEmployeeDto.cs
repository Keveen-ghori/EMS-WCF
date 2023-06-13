using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.DTO.Employee
{
    [DataContract]
    public class CreateEmployeeDto : IExtensibleDataObject
    {
        [DataMember]
        public string FirstName { get; set; } = string.Empty;
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; } = string.Empty;
        [DataMember]
        public string Password { get; set; } = String.Empty;
        [NotMapped]
        [DataMember]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [DataMember]
        public DateTime? DOB { get; set; }

        /// <summary>
        /// Default value from num class
        /// </summary>
        [DataMember]
        public byte Gender { get; set; } = 1;

        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
