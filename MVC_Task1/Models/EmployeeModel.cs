    using static MVC_Task1.Models.Enums;

    namespace MVC_Task1.Models
    {
        public class EmployeeModel
        {
            public int Id { get; set; }
            public string UserId { get; set; }
            public ApplicationUserModel User { get; set; }
            public string Name { get; set; }
            public DateOnly BirthDay { get; set; }
            public string PhoneNumber { get; set; }
            public string NationalId { get; set; }
            public string Nationaly { get; set; }
            public MaritalStatus MaritalStatus { get; set; }
            public string PersonalPhoto { get; set; }
            public DateOnly EntryDate { get; set; }
            public int DepartmentId { get; set; }
            public DepartmentModel Department { get; set; }
            public ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>();

        }
    }
