using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Consultant
    {
        public int Id { get; set; }
        public string Name{get; set; }
        public string Charge { get; set; }
        public int PendingVacations { get; set; }
        public DateTime PenultimateVac { get; set; }
        public DateTime LastVacation { get; set; }
        public double YearsNoVacation { get; set; }
        public bool Required { get; set; }
        public bool ShouldApprove { get; set; }
        public bool Approved { get; set; }

        //Relations
        public List<RequestConsultant> ClientConsultants { get; set; } = new List<RequestConsultant>();
        public int OfficeId { get; set; }
        public Office Office { get; set; }


        
    }
}
