using Microsoft.AspNetCore.Identity;


namespace ShopTARgv23.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }

        public string FirstName { get; set; }
    }
}