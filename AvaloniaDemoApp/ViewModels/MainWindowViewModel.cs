using Avalonia.Collections;
using Avalonia.Controls;
using AvaloniaDemoApp.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AvaloniaDemoApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        private NavigationViewItem? _selectedMenuItem;
        public NavigationViewItem? SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => this.RaiseAndSetIfChanged(ref _selectedMenuItem, value);
        }

        private ReactiveObject? _currentViewModel;
        public ReactiveObject? CurrentViewModel
        {
            get => _currentViewModel;
            set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
        }

        public AvaloniaList<NavigationViewItem> MenuItems { get; } = new()
        {
        new NavigationViewItem { Label = "Home", Icon = null, Target = typeof(HomeViewModel) },
        new NavigationViewItem { Label = "First", Icon = null, Target = typeof(FirstViewModel) },
        new NavigationViewItem { Label = "Second", Icon = null, Target = typeof(SecondViewModel) },
        new NavigationViewItem { Label = "Settings", Icon = null, Target = typeof(SettingsViewModel) }
        };

        private ICommand? _menuItemInvokedCommand;
        public ICommand? MenuItemInvokedCommand => _menuItemInvokedCommand ??= ReactiveCommand.Create(OnMenuItemInvoked);


        private void OnMenuItemInvoked()
        {
            if (SelectedMenuItem != null)
            {
                NavigateTo(SelectedMenuItem.Target);
            }
        }

        private void NavigateTo(Type? target)
        {
            if (target.Name == "HomeViewModel")
                CurrentViewModel = new HomeViewModel();

            if (target.Name == "FirstViewModel")
                CurrentViewModel = new FirstViewModel();

            if (target.Name == "SecondViewModel")
                CurrentViewModel = new SecondViewModel();

            if (target.Name == "SettingsViewModel")
                CurrentViewModel = new SettingsViewModel();
        }
    }
}
