using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace XamlImprovements.Menu
{
    public class MenuItem
    {
        public Symbol Icon { get; set; }
        public string Name { get; set; }
        public Type PageType { get; set; }
        public string AccessKey { get; set; }
        public ToolTip Tooltip { get; set; }

        public static List<MenuItem> GetMainItems()
        {
            var items = new List<MenuItem>();
            items.Add(new MenuItem { Icon = Symbol.Accept, Name = "Edit and continue", PageType = typeof(Views.EditAndContinue), AccessKey = "E", Tooltip = new ToolTip { Content = "E" } });
            items.Add(new MenuItem() { Icon = Symbol.Send, Name = "New binding features", PageType = typeof(Views.NewBindingFeatures), AccessKey = "B", Tooltip = new ToolTip { Content = "B" } });
            items.Add(new MenuItem() { Icon = Symbol.Message, Name = "Chat window", PageType = typeof(Views.ChatWindow), AccessKey = "C", Tooltip = new ToolTip { Content = "C" } });
            return items;
        }
    }

}
