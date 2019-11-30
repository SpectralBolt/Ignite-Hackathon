using Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Helpers;
using ApiRest.Services;

namespace ApiRest.Repository
{
    public class Repository:IRepository
    {
        private readonly BankDbContext context;

        public Repository(BankDbContext context)
        {
            this.context = context;
            if (context.Offices.Any())
                return;
            LoadData();
        }

        public async Task AddClient(Client client)
        {
            await context.Clients.AddAsync(client);
            await context.SaveChangesAsync();
        }

        public async Task AddRequest(Request request, int clientId)
        {
            await context.Requests.AddAsync(request);
            context.Clients.Where(c => c.Id == clientId).FirstOrDefault().Requests.Add(request);
            await context.SaveChangesAsync();
        }

        public Task AsignRequestConsultant(Request request, Consultant consultant)
        {
            throw new NotImplementedException();
        }

        public Task AddOffice(Office office)
        {
            throw new NotImplementedException();
        }

        public Task AddConsultant(Consultant consultant, int officeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Consultant>> GetConsultants(int officeId)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClient(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Office> Getoffice(int officeId)
        {
            throw new NotImplementedException();
        }

        #region Seed Database
        private void LoadData()
        {
            LoadClients();
            LoadFromCSV();

        }
        private void LoadClients()
        {
            List<Client> clients = new List<Client>
            {
                new Client{Name="Manuel Alejandro", LstName="Ordoñez",   Cc="1026301545"},
                new Client{Name="Jorge Ivan",       LstName="Echeverri", Cc="1152202523"},
                new Client{Name="Lina",             LstName="Perez",     Cc="1513254622"},
            };
            context.Clients.AddRange(clients);
            context.SaveChanges();
        }
        private void LoadFromCSV()
        {
            // ConsultantsD:\VS Projects\Ignite\Consultant\Common\CSV\ClientesOficina.csv
            List<Consultant> consultants = File.ReadAllLines("D:\\VS Projects\\Ignite\\Consultant\\Common\\CSV\\Vacaciones.csv")
                                           .Skip(1)
                                           .Select(v => Parsers.ParseConsultant(v))
                                           .ToList();
            context.Consultants.AddRange(consultants);
            context.SaveChanges();
            List<Office> offices = File.ReadAllLines("D:\\VS Projects\\Ignite\\Consultant\\Common\\CSV\\OficinasColpatriaBogota.csv")
                                    .Skip(1)
                                    .Select(l => Parsers.ParseOffice(l))
                                    .ToList();
            List<Record> records = File.ReadAllLines("D:\\VS Projects\\Ignite\\Consultant\\Common\\CSV\\ClientesOficina.csv")
                                    .Skip(1)
                                    .Select(r => Parsers.ParseRecord(r))
                                    .ToList();
            foreach (var item in offices)
            {
                item.Consultants.AddRange(consultants.Where(c => c.OfficeId == item.OfficeId));
                item.Records.AddRange(records.Where(r => r.OfficeId == item.OfficeId));
            }
            context.AddRange(offices);
            context.SaveChanges();
        }

        #endregion
    }
}
