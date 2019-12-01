using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public class EmailMessage : IEmailMessage
    {
        public Task<bool> SendEmailVacationRequest(List<DateTime> dates, Consultant consultant)
        {
            throw new NotImplementedException();
        }
    }
}
