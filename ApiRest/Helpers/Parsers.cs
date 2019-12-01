using Common.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Helpers
{
    public static class Parsers
    {
        public static int Counter { get; set; }
        public static Consultant ParseConsultant(string line)
        {
            Counter++;
            Debug.WriteLine(Counter);
            var consultant = new Consultant();
            string[] columns = line.Split(';');
            string[] penulDate = columns[4].Split('/');
            string[] lastDate = columns[5].Split('/');
            consultant.Name = columns[0];
            consultant.OfficeId = string.IsNullOrEmpty(columns[1]) ? RandOffice() : int.Parse(columns[1]);
            consultant.Charge = columns[2];
            consultant.PendingVacations = int.Parse(columns[3]);
            consultant.PenultimateVac = GetTime(penulDate);
            consultant.LastVacation = GetTime(lastDate);
            consultant.YearsNoVacation = NumberOfYears(consultant.LastVacation);
            consultant.Required = consultant.YearsNoVacation > 1;
            consultant.ShouldApprove = IsApproved(consultant.Required,consultant.YearsNoVacation);
            return consultant;
        }
        private static double NumberOfYears(DateTime lastVacation)
        {
            var res = DateTime.Now.Subtract(lastVacation);
            double result = res.TotalDays;
            return (result / 365);
        }
        private static bool IsApproved(bool required, double yearsNoVacation) => required || yearsNoVacation > 0.5;

        private static int RandOffice()
        {
            int[] offices = { 23, 24, 197, 432, 923, 63, 66, 48, 79, 12 };
            Random rn = new Random();
            return offices[rn.Next(0, offices.Length)];
        }

        public static Office ParseOffice(string l)
        {
            string[] line = l.Split(';');
            var office = new Office();
            office.Name = line[0];
            office.OfficeCod = int.Parse(line[1]);
            office.Adress = line[2];
            office.Atms = int.Parse(line[3]);
            return office;
        }
        public static Record ParseRecord(string l)
        {
            string[] line = l.Split(',');
            string []date = line[2].Split('/');
            var record = new Record
            {
                OfficeId = int.Parse(line[0]),
                Clients = int.Parse(line[1]),
                Date = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0])),
                Waiting = int.Parse(line[3].Split(':')[1])
            };
            return record;
        }
        public static DateTime GetTime(string [] date)
        {
            return date.Length>=3? new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0])):DateTime.MinValue;
        }
    }
}
