using System;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OutOfProcessBackgroundTasks
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
            builder.TaskEntryPoint = "MyBackgroundTask.TimeZoneChangedTask";
            builder.SetTrigger(new SystemTrigger(SystemTriggerType.TimeZoneChange, false));
            var status = await BackgroundExecutionManager.RequestAccessAsync();
            if (status != BackgroundAccessStatus.DeniedByUser && status != BackgroundAccessStatus.DeniedBySystemPolicy)
            {
                builder.Register();
            }
        }
    }
}
