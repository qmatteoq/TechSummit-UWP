using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace XamlImprovements.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChatWindow : Page
    {
        private ObservableCollection<string> Messages;

        public ChatWindow()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Messages = new ObservableCollection<string>
            {
                "Message one",
                "Message two",
                "Message three",
                "Message four",
                "Message five",
                "Message six",
                "Message seven",
                "Message eight",
                "Message nine",
                "Message ten"
            };

            MessagesListView.ItemsSource = Messages;
        }

        private void OnSendMessage(object sender, RoutedEventArgs e)
        {
            Messages.Add(MessageTextBox.Text);
            MessageTextBox.Text = string.Empty;
        }
    }
}
