using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Consultant.Models
{
    public class FilterItem:ViewModels.BaseViewModel
    {
        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        private bool _state;

        public bool State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }
        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
        public Color Color => State ? Colors.Green : Colors.Black;


    }
}
