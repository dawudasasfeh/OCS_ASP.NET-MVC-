namespace MVC_Task1.Models
{
    public class MangerModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUserModel User { get; set; }
        public string Name { get; set; }
    }
}
