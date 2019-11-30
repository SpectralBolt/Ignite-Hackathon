using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultant.Helpers
{
    public class Speech2TextHelper
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public static async Task<string> RecognizeSpeechAsync()
        {
            Debug.WriteLine("Starting Speech2Text service...");
            var config = SpeechConfig.FromSubscription("d882cca2d3b44735b0760cbaece4b340", "westus");
            config.SpeechRecognitionLanguage = "es-MX";
            using (var audioInput = AudioConfig.FromWavFileInput(@"D:\VS Projects\Ignite\Consultant\Consultant\Speech.wav"))
            {
                using (var recognizer = new SpeechRecognizer(config, audioInput))
                {
                    Debug.WriteLine("Recognizing first result...");
                    var result = await recognizer.RecognizeOnceAsync();

                    if (result.Reason == ResultReason.RecognizedSpeech)
                    {
                        Debug.WriteLine($"We recognized: {result.Text}");
                        return result.Text;
                    }
                    else if (result.Reason == ResultReason.NoMatch)
                    {
                        Debug.WriteLine($"NOMATCH: Speech could not be recognized.");
                        return "Not recognized";
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
                        return "Canceled";
                    }
                    return "";
                }
            }
        }
        public static List<string> GetMainWords(string result)
        {
            var  strings=result.Split(" ");
            foreach (var item in strings)
            {
                Debug.WriteLine(item);
            }
            return strings.ToList();
        }

        public static async Task RecognizeSpeechAsyncMic()
        {
            Console.WriteLine("Starting Speech2Text service...");
            var config = SpeechConfig.FromSubscription("d882cca2d3b44735b0760cbaece4b340", "westus");
            config.SpeechRecognitionLanguage = "es-MX";
            using (var recognizer = new SpeechRecognizer(config))
            {
                await recognizer.StartContinuousRecognitionAsync();
                recognizer.Recognizing += Recognizer_Recognizing;
                await Task.Delay(TimeSpan.FromMinutes(1));
                await recognizer.StopContinuousRecognitionAsync();
            }
        }

        private static void Recognizer_Recognizing(object sender, SpeechRecognitionEventArgs e)
        {
            var result = e.Result;

            if (result.Reason == ResultReason.RecognizingSpeech)
            {
                Console.WriteLine($"We recognized: {result.Text}");
            }
            else if (result.Reason == ResultReason.NoMatch)
            {
                Console.WriteLine($"NOMATCH: Speech could not be recognized.");
            }
            else if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = CancellationDetails.FromResult(result);
                Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                if (cancellation.Reason == CancellationReason.Error)
                {
                    Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                    Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                    Console.WriteLine($"CANCELED: Did you update the subscription info?");
                }
            }
        }
    }
}
