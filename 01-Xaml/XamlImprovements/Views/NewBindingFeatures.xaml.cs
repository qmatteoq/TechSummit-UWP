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
using XamlImprovements.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace XamlImprovements.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewBindingFeatures : Page
    {
        public NewBindingFeatures()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ObservableCollection<Person> customers = new ObservableCollection<Person>
            {
                new Person
                {
                    Name = "Matteo",
                    Surname = "Pagani",
                    IsMvp = false
                },
                new Person
                {
                    Name = "Marco",
                    Surname = "Dal Pino",
                    IsMvp = true
                },
                new Person
                {
                    Name = "Marco",
                    Surname = "Minerva",
                    IsMvp = true
                }
            };

            Customers.ItemsSource = customers;
        }

       
    }
}
