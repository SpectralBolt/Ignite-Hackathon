using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Consultant.Helpers;
using Consultant.ViewModels;
using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml.Hosting;
using Consultant.Views;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Consultant
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            DataContext = Startup.ServiceProvider.GetService<MainPageViewModel>();
            this.InitializeComponent();;
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Window.Current.Content = new Consultant1();
        }
    }
}
/*
 * 
 * public ObservableCollection<MenuItem> MenuItems { get; set; }
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


    private void OutputTextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var text =(TextBlock)sender;
            var vm = (MainPageViewModel)DataContext;
            if (!string.IsNullOrEmpty(text.SelectedText)){
                Debug.WriteLine(text.SelectedText);
                vm.AddExtraMainWord(text.SelectedText);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = (MainPageViewModel)DataContext;
            vm.RecognizeSpeechAsyncMic();
        }
 * 
 * */
