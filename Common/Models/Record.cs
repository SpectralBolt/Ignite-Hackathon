using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Record
    {
        public int Id { get; set; }
        public int Clients { get; set; }
        public DateTime Date { get; set; }
        public int Waiting { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
