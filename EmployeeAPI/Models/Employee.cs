using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        public  int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [EmailAddress (ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Range(0, 1, ErrorMessage = "Inform if it is Active (1) ou Not Active (0)")]
        public int IsActive { get; set; }
    }
}
