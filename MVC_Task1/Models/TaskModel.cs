using static MVC_Task1.Models.Enums;

namespace MVC_Task1.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }
        public string Title { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly DueDate { get; set; }
        public string Description { get; set; }
        public TaskImportance ImportanceLevel { get; set; }

    }
}
