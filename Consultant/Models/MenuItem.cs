using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultant.Models
{
    public class MenuItem
    {
        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
        private Type _navigationPage;

        public Type NavigationPage
        {
            get { return _navigationPage; }
            set { _navigationPage = value; }
        }
    }
}
