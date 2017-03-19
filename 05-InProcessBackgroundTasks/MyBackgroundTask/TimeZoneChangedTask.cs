using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace MyBackgroundTask
{
    public sealed class TimeZoneChangedTask: IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            string xml = $@"<toast>
            <visual>
                <binding template='ToastGeneric'>
                    <text>Time zone has changed!</text>
                    <text>Check the new time zone!</text>
                </binding>
            </visual>
        </toast>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            ToastNotification toast = new ToastNotification(doc);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
