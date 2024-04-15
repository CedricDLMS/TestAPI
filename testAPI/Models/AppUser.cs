using Microsoft.AspNetCore.Identity;

namespace testAPI.Models
{
    public class AppUser : IdentityUser
    {
        public Client Client { get; set; }
        public int Age {  get; set; }

        

    }
}
