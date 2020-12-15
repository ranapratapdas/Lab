using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabAPI.Services
{
    public interface IEmailManager
    {
        public Task SendEmail(string to, string from, string body, string subject);
    }
}
