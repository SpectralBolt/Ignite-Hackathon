using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Speech2Text_test
{
    class Program
    {
        static void Main(string[] args)
        {
            RecognizeSpeechAsync().Wait();
            RecognizeSpeechAsyncMic().Wait();
            Console.WriteLine("Press any key...");
            Console.ReadLine();
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

        public static async Task RecognizeSpeechAsync()
        {
            Console.WriteLine("Starting Speech2Text service...");
            var config = SpeechConfig.FromSubscription("d882cca2d3b44735b0760cbaece4b340", "westus");
            config.SpeechRecognitionLanguage="es-MX";
            using (var audioInput = AudioConfig.FromWavFileInput(@"D:\VS Projects\Ignite\Consultant\Speech2Text_test\Speech.wav"))
            {
                using ( var recognizer = new SpeechRecognizer(config, audioInput))
                {
                    Console.WriteLine("Recognizing first result...");
                    var result = await recognizer.RecognizeOnceAsync();

                    if (result.Reason == ResultReason.RecognizedSpeech)
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
    }
}
