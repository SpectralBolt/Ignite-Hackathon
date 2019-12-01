using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public interface IEmailMessage
    {
        Task<bool> SendEmailVacationRequest(List<DateTime> dates, Consultant consultant);
    }
}
