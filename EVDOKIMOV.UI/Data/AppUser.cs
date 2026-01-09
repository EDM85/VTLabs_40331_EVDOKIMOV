using Microsoft.AspNetCore.Identity;

namespace EVDOKIMOV.UI.Data
{
    public class AppUser : IdentityUser
    {
        public byte[]? Avatar {  get; set; }
    }
}
