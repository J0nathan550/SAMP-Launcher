using SAMP.API;
using System.Windows;

namespace SAMP_Launcher.WPF;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        UpdateServerList().ConfigureAwait(false);
    }

    private async Task UpdateServerList()
    {
        await Dispatcher.InvokeAsync(() => // Run on the UI thread
        {
            gameServerDataGrid.ItemsSource = null;
            loadingLabel.Text = "Loading...";
            loadingLabel.Visibility = Visibility.Visible;
        });

        try
        {
            var servers = await SAMPQuery.GetServersAsync().ConfigureAwait(false);

            await Dispatcher.InvokeAsync(() => // Run on the UI thread
            {
                if (servers != null)
                {
                    gameServerDataGrid.ItemsSource = servers;
                    loadingLabel.Visibility = Visibility.Hidden;
                }
                else
                {
                    // Handle the case when servers are not retrieved
                    loadingLabel.Text = "Failed to retrieve servers.";
                }
            });
        }
        catch (Exception ex)
        {
            // Handle unexpected exceptions during server list update
            Console.WriteLine($"Error updating server list: {ex.Message}");
        }
    }

    private async void RefreshItem_Click(object sender, RoutedEventArgs e)
    {
        await UpdateServerList();
    }
}