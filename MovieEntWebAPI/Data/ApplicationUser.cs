using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MovieEntWebAPI.Data
{
    public class ApplicationUser:IdentityUser
    {
        [StringLength(240)]
        public string FirstName { get; set; }

        [StringLength(240)]
        public string LastName { get; set; }

    }
}
