using Microsoft.AspNetCore.Identity;

namespace LisbrarySystem.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Buy> Buys { get; set; }

        public virtual ICollection<Borrow> Borrows { get; set; }

    }
}
