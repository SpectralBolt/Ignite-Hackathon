using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Consultant.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Calendar : Page
    {
        public Calendar()
        {
            this.InitializeComponent();
            Calend.SelectedDates.Add(new DateTime(2019, 11, 5));
            Calend.SelectedDates.Add(new DateTime(2019, 11, 6));
            Calend.SelectedDates.Add(new DateTime(2019, 11, 7));
            
            
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PopupCalendar.IsOpen = !PopupCalendar.IsOpen;
        }
    }
}
