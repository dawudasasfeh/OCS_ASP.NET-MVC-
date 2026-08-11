namespace MVC_Task1.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
        
    }
}
