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
        public int YearsNoVacation { get; set; }
        public bool Required { get; set; }
        public bool ShouldApprove { get; set; }
        public bool Approved { get; set; }

        //Relations
        public List<ClientConsultant> ClientConsultants { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }


        public void VacationFromCSV(string line)
        {
            string[] columns = line.Split(';');
            string[] penulDate = columns[4].Split('/');
            string[] lastDate = columns[5].Split('/');
            Name = columns[0];
            OfficeId = string.IsNullOrEmpty(columns[1]) ? RandOffice() : int.Parse(columns[1]);
            Charge = columns[2];
            PendingVacations = int.Parse(columns[3]);
            PenultimateVac = new DateTime(int.Parse(penulDate[2]), int.Parse(penulDate[1]), int.Parse(penulDate[1]));
            LastVacation = new DateTime(int.Parse(lastDate[2]), int.Parse(lastDate[1]), int.Parse(lastDate[1]));
            YearsNoVacation = NumberOfMonths();
            Required = YearsNoVacation > 1;
            ShouldApprove = IsApproved();
        }

        private int NumberOfMonths()
        {
            var res = DateTime.Now.Subtract(LastVacation);
            double result = res.TotalDays;
            return (int)(result / 365);
        }
        private bool IsApproved() => Required||YearsNoVacation>0.5;

        private int RandOffice()
        {
            int[] offices = { 23, 24, 197, 432, 923, 63, 66, 48, 79, 12 };
            Random rn = new Random();
            return offices[rn.Next(0, offices.Length)];
        }
    }
}
