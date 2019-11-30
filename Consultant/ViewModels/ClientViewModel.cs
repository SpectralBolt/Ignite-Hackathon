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
    public class ClientViewModel:BaseViewModel
    {
        public ObservableCollection<string> MainWords { get; set; }
        public ObservableCollection<string> ListWords { get; set; }
        private readonly CoreDispatcher dispatcher;
        private string _currentMessage = "Inicio";

        public string CurrentMessage
        {
            get => _currentMessage;
            set
            {

                if (this.dispatcher.HasThreadAccess)
                {
                    SetProperty(ref _currentMessage, value);
                    GetMainWords();
                }
                else
                {

                    var task = this.dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        SetProperty(ref _currentMessage, value);
                        GetMainWords();
                    });
                }
                Debug.WriteLine(_currentMessage);
                //GetMainWords();
            }
        }

        public ClientViewModel()
        {
            MainWords = new ObservableCollection<string>();
            ListWords = new ObservableCollection<string> { "hola", "problema", "factura", "codensa" };
            this.dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
            EnableMic();
        }



        public async void EnableMic()
        {
            bool isMicAvailable = true;
            try
            {
                var mediaCapture = new Windows.Media.Capture.MediaCapture();
                var settings = new Windows.Media.Capture.MediaCaptureInitializationSettings();
                settings.StreamingCaptureMode = Windows.Media.Capture.StreamingCaptureMode.Audio;
                await mediaCapture.InitializeAsync(settings);
            }
            catch (Exception)
            {
                isMicAvailable = false;
            }
            if (!isMicAvailable)
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-microphone"));
            }
            else
            {
                Debug.WriteLine("Mic was enabled");
            }
        }
        public async void RecognizeSpeechAsyncMic()
        {
            Debug.WriteLine("Starting Speech2Text service...");
            var config = SpeechConfig.FromSubscription("d882cca2d3b44735b0760cbaece4b340", "westus");
            config.SpeechRecognitionLanguage = "es-MX";
            using (var recognizer = new SpeechRecognizer(config))
            {
                await recognizer.StartContinuousRecognitionAsync();
                recognizer.Recognizing += Recognizer_Recognizing;
                recognizer.Recognized += Recognizer_Recognized;
                await Task.Delay(TimeSpan.FromMinutes(1));
                await recognizer.StopContinuousRecognitionAsync();

            }
        }

        private void Recognizer_Recognized(object sender, SpeechRecognitionEventArgs e)
        {
            Debug.WriteLine(e.Result.Text);
        }

        private void Recognizer_Recognizing(object sender, SpeechRecognitionEventArgs e)
        {
            var result = e.Result;

            if (result.Reason == ResultReason.RecognizingSpeech)
            {
                Debug.WriteLine($"We recognized: {result.Text}");
                CurrentMessage = $" {result.Text}";
            }
            else if (result.Reason == ResultReason.NoMatch)
            {
                Debug.WriteLine($"NOMATCH: Speech could not be recognized.");
            }
            else if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = CancellationDetails.FromResult(result);
                Debug.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                if (cancellation.Reason == CancellationReason.Error)
                {
                    Debug.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                    Debug.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                    Debug.WriteLine($"CANCELED: Did you update the subscription info?");
                }
            }
        }
        public void GetMainWords()
        {
            var strings = CurrentMessage.Split(" ").ToList();
            foreach (var item in strings)
            {
                if (ListWords.Contains(item.Trim()) && !MainWords.Contains(item.Trim()))
                    MainWords.Add(item.Trim());
            }

        }
        public void AddExtraMainWord(string word)
        {
            if (!MainWords.Contains(word))
            {
                MainWords.Add(word);
            }
        }
    }
}
