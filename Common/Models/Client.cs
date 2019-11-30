using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LstName { get; set; }
        public string Cc { get; set; }

        public List<ClientConsultant> ClientConsultants { get; set; }
    }
}
