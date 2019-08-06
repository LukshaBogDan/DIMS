using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.EF.DAL.Identity.Models
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
            PasswordValidator = new MinimumLengthValidator(4);
            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(3);
            MaxFailedAccessAttemptsBeforeLockout = 5;
            UserTokenProvider = new EmailTokenProvider<ApplicationUser>();
        }
    }
}
