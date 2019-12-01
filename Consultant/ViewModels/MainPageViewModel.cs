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
        public MainPageViewModel()
        {
            Items = new ObservableCollection<MenuItem>
            {
                new MenuItem{ Image="\uE80F", NavigationPage=typeof(Home)},
                new MenuItem{ Image="\uE787", NavigationPage= typeof(Calendar)},
                new MenuItem{ Image="\uE77B", NavigationPage=typeof(Profile)},
                new MenuItem{ Image="\uE719", NavigationPage=typeof(Cash)},
                new MenuItem{ Image="\uE8C9", NavigationPage=typeof(Information)},
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
