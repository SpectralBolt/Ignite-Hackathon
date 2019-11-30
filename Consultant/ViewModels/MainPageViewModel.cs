using Consultant.Models;
using Consultant.Views;
using Microsoft.CognitiveServices.Speech;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace Consultant.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<MenuItem> Items { get; set; }
        public string MyProperty { get; set; }
        public MainPageViewModel()
        {
            Items = new ObservableCollection<MenuItem>
            {
                new MenuItem{ Image="Images/Home.jpeg", NavigationPage=typeof(Home)},
                new MenuItem{ Image="Images/Calendar.jpeg", NavigationPage= typeof(Calendar)},
                new MenuItem{ Image="Images/Profile.jpeg", NavigationPage=typeof(Profile)}
            };
        }


        #region Properties
        private string title;

        public string Title
        {
            get { return this.title; }
            set { SetProperty(ref (title), value); }
        }
        private bool isOpened = false;



        public bool IsOpened
        {
            get { return isOpened; }
            set { SetProperty(ref isOpened, value); }
        }
        #endregion
    }
}
