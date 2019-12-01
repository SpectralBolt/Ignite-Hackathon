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
            System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate (
            object sender,
            X509Certificate cert,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
                    {
                        if (sslPolicyErrors == SslPolicyErrors.None)
                        {
                            return true;   //Is valid
                        }

                        if (cert.GetCertHashString() == "2c38449dc9ad99d12eb0b6197f99e60c8706a399")
                        {
                            return true;
                        }

                        return false;
                    };
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<List<Office>>(content);
            foreach (var item in items)
            {
                Offices.Add(item);
            }
        }

    }//2c38449dc9ad99d12eb0b6197f99e60c8706a399
}
