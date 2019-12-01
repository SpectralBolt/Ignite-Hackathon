using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public bool IsOpened { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<RequestConsultant> RequestConsultants { get; set; } = new List<RequestConsultant>();
    }
}
