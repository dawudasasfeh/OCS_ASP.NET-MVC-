using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Validation_in_ASP.NET__Client_Side_vs_Server_Side_.Models
{
    public class Employee
    {      
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Range(15, int.MaxValue, ErrorMessage = "Value must be a bigger than 15.")]
        public int Age { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Value must be a positive number.")]
        public Decimal Salary { get; set; }

    }
}
