// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using ExpenseItDemo.Data.Model;
using System.Windows;

namespace ExpenseItDemo
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        public Employee SelectedEmployee { get; set; }
    }
}