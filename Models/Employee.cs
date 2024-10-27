using Microsoft.AspNetCore.Identity;


namespace Information_system_i_ASP.Net.Models
{
    public class Employee : IdentityUser
    {
        public string Name { get; set; }

    }
}
