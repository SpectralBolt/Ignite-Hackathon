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
            DataContext = new MainPageViewModel();
            this.InitializeComponent();
        }

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
    }
}
