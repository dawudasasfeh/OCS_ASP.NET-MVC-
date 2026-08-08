using System.ComponentModel.DataAnnotations;

namespace ASP_Task_1.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, int.MaxValue)]
        public int Age { get; set; }

    }
}
