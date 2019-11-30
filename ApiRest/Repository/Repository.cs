using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Repository
{
    public class Repository
    {
        private readonly BankDbContext context;

        public Repository(BankDbContext context)
        {
            this.context = context;
            if (context.Clients.Any())
                return;
            LoadDataFromCSV();
        }
        #region Seed Database
        private void LoadDataFromCSV()
        {


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

        #endregion
    }
}
