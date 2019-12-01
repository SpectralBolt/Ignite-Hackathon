using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Consultant.ViewModels;
using Consultant.Models;
using Windows.UI.Xaml.Media.Imaging;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Consultant.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Consultant1 : Page
    {
        public Consultant1(Type currentPage)
        {
            DataContext = Startup.ServiceProvider.GetService<MainPageViewModel>();
            this.InitializeComponent();
            NavigationFrame.Navigate(currentPage);
        }

        private void ListPane_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as MenuItem;
            NavigationFrame.Navigate(item.NavigationPage);
        }
    }
}
