using System;
using System.Collections.Generic;
using System.Text;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Input.Inking;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InkSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Canvas.InkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Mouse | Windows.UI.Core.CoreInputDeviceTypes.Pen | Windows.UI.Core.CoreInputDeviceTypes.Touch;
        }

        private async void OnSaveImage(object sender, RoutedEventArgs e)
        {
            IReadOnlyList<InkStroke> strokes = Canvas.InkPresenter.StrokeContainer.GetStrokes();
            if (strokes.Count > 0)
            {
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.SuggestedStartLocation =
                    PickerLocationId.PicturesLibrary;
                savePicker.FileTypeChoices.Add(
                    "GIF",
                    new List<string> { ".gif" });
                savePicker.DefaultFileExtension = ".gif";
                savePicker.SuggestedFileName = "InkSample";

                // Show the file picker.
                StorageFile file = await savePicker.PickSaveFileAsync();

                if (file != null)
                {
                    IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite);
                    // Write the ink strokes to the output stream.
                    using (IOutputStream outputStream = stream.GetOutputStreamAt(0))
                    {
                        await Canvas.InkPresenter.StrokeContainer.SaveAsync(outputStream);
                        await outputStream.FlushAsync();
                    }
                    stream.Dispose();
                }
            }
        }

        private async void OnRecognizeText(object sender, RoutedEventArgs e)
        {
            int resultsNumber = 0;

            InkRecognizerContainer inkRecognizer = new InkRecognizerContainer();
            var recognitionResults = await inkRecognizer.RecognizeAsync(Canvas.InkPresenter.StrokeContainer, InkRecognitionTarget.All);
            string str = string.Empty;
            foreach (InkRecognitionResult result in recognitionResults)
            {
                // Get all recognition candidates from each recognition result.
                IReadOnlyList<string> candidates = result.GetTextCandidates();
                resultsNumber = candidates.Count;
                foreach (string candidate in candidates)
                {
                    str += $"{candidate} | ";
                }
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Number of recognized words: {resultsNumber}");
            builder.AppendLine("Recognized text:");
            builder.AppendLine(str);

            MessageDialog dialog = new MessageDialog(str);
            await dialog.ShowAsync();
        }
    }
}
