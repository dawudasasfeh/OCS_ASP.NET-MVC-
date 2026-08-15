using Microsoft.AspNetCore.Identity;


namespace MVC_Task3.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; }
    }
}
