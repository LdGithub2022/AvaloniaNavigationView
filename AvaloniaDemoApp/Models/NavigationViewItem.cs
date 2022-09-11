using System;

namespace AvaloniaDemoApp.Models
{
    public class NavigationViewItem
    {
        public string? Label { get; set; }
        public object? Icon { get; set; }
        public Type? Target { get; set; }
    }
}
