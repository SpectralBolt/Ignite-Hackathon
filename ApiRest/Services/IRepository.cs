using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public interface IRepository
    {
        Task AddClient(Client client);
        Task AddRequest(Request request, int ClientId);
        Task AsignRequestConsultant(Request request, Consultant consultant);
        Task AddOffice(Office office);
        Task AddConsultant(Consultant consultant, int officeId);
        Task<List<Consultant>> GetConsultants(int officeId);
        Task<Client> GetClient(int clientId);
        Task<Office> GetOffice(int officeId);
        Task<IEnumerable<Office>> GetOfficesAsync();
    }
}
