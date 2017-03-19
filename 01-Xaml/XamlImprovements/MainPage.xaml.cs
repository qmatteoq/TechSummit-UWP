using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using XamlImprovements.Menu;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace XamlImprovements
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
            hamburgerMenuControl.ItemsSource = MenuItem.GetMainItems();
        }

        private void OnAccessKeyPressed(UIElement sender, AccessKeyDisplayRequestedEventArgs args)
        {
            ToolTip tooltip = ToolTipService.GetToolTip(sender) as ToolTip;
            tooltip.IsOpen = true;
        }

        private void OnAccessKeyDismissed(UIElement sender, AccessKeyDisplayDismissedEventArgs args)
        {
            ToolTip tooltip = ToolTipService.GetToolTip(sender) as ToolTip;
            tooltip.IsOpen = false;
        }

        private void OnGoToPage(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MenuItem menuItem = button.DataContext as MenuItem;
            Frame.Navigate(menuItem.PageType);
        }
    }
}
