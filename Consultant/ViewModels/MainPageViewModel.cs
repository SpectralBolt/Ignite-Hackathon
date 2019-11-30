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
        public ObservableCollection<MenuItem> MenuItems { get; set; }
        public MainPageViewModel()
        {
            MenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem{Name="Ventas",         Description="Registro de ventas",    Glyph="\uE719", NavigationPage=typeof(SalesView)},
                new MenuItem{Name="Inventario",     Description="Productos en Stock",    Glyph="\uE71C", NavigationPage=typeof(SalesView)},
                new MenuItem{Name="Deudas",         Description="Cuentas por pagar",     Glyph="\uE8FB", NavigationPage=typeof(SalesView)},
                new MenuItem{Name="Inversion",      Description="Registro de ventas",    Glyph="\uE7C1", NavigationPage=typeof(SalesView)},
                new MenuItem{Name="Proveedores",    Description="Contactos proveedores", Glyph="\uE780", NavigationPage=typeof(SalesView)},
            };

            OpenFlyoutCommand = new RelayCommand(() => IsOpened = !IsOpened);
            Title = "Testing ServiceProvider";
        }

        public RelayCommand OpenFlyoutCommand { get; set; }


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
