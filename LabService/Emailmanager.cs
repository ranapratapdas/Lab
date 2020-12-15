using LabAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LabAPI.Services
{
    public class Emailmanager : IEmailManager
    {
        public async Task SendEmail(string to, string from, string body, string subject)
        {
            //Send email
            return;
        }
    }
}
