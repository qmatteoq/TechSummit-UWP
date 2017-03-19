using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InProcessBackgroundTasks
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

        private async void OnRegisterTask(object sender, RoutedEventArgs e)
        {
            BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
            builder.Name = "TimeZoneTriggerBackgroundTask";
            builder.SetTrigger(new SystemTrigger(SystemTriggerType.TimeZoneChange, false));
            var status = await BackgroundExecutionManager.RequestAccessAsync();
            if (status != BackgroundAccessStatus.DeniedByUser && status != BackgroundAccessStatus.DeniedBySystemPolicy)
            {
                builder.Register();
            }
        }
    }
}
