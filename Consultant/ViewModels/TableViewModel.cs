using Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.Web.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Consultant.ViewModels
{
    public class TableViewModel
    {
        private HttpClient http;
        public ObservableCollection<Office> Offices { get; set; }
        public TableViewModel()
        {
            http = new HttpClient();
            Offices = new ObservableCollection<Office>();
            LoadRecords();
        }

        private async void LoadRecords()
        { 
            var response=await http.GetAsync(new Uri("https://localhost:44371/api/Office"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<List<Office>>(content);
            foreach (var item in items)
            {
                Offices.Add(item);
            }
        }
    }
}
