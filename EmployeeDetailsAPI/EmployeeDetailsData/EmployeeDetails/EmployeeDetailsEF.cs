using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDetailsData.EmployeeDetails
{
    [Table("EmployeeDetails")]
    public class EmployeeDetailsEF
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
    }
}
