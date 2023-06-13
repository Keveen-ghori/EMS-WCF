using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Data.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public long EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime? Dob { get; set; }

        public byte Gender { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int? Attemps { get; set; }

        public int TotalAttemps { get; set; }

        public bool? Status { get; set; }

        public bool? IsLocked { get; set; }

        public string UserName { get; set; }

        public int? ExpDays { get; set; }

        public DateTime? PasswordUpdatedAt { get; set; }
    }
}
