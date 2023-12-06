using Avalonia.Controls;
using Avalonia.Media;
using SAMP_Launcher.Models;
using System;

namespace SAMP_Launcher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowModel();
            CheckIfCustomTitlebarAvailable();
        }

        private void CheckIfCustomTitlebarAvailable()
        {
            if (!OperatingSystem.IsWindowsVersionAtLeast(7))
            {
                mainWindowGrid.RowDefinitions = new RowDefinitions();
                mainWindowGrid.Children.Remove(customTitleBar);
                mainWindowGrid.Children.Remove(acrylBackground);
                ExtendClientAreaToDecorationsHint = false;
                Background = new SolidColorBrush(new Color(255, 21, 21, 21));
            }
        }
    }
}