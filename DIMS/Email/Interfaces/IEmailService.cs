using HIMS.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Email.Interfaces
{
    public interface IEmailService
    {
        Task MessageToUserAsync(UserDTO user, string subject, string html);
        Task MessageToUserAsync(IEnumerable<UserDTO> users, string subject, string html);
    }
}
