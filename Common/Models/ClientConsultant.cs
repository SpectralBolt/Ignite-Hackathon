using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class ClientConsultant
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ConsultantId { get; set; }
        public Consultant Consultant { get; set; }
    }
}
