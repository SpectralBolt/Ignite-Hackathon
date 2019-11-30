using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class RequestConsultant
    {
        public int RequestId { get; set; }
        public Request Request { get; set; }

        public int ConsultantId { get; set; }
        public Consultant Consultant { get; set; }
    }
}
