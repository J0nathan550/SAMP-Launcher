using SAMP.API;
using System.Diagnostics;
using System.Windows;

namespace SAMP_Launcher.WPF;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        UpdateServerList().ConfigureAwait(false);
    }

    private async Task UpdateServerList()
    {
        await Dispatcher.InvokeAsync(() =>
        {
            gameServerDataGrid.ItemsSource = null;
            loadingLabelAllServers.Text = "Loading...";
            loadingLabelAllServers.Visibility = Visibility.Visible;
        });

        try
        {
            var servers = await SAMPQuery.GetServersAsync().ConfigureAwait(false);

            await Dispatcher.InvokeAsync(() =>
            {
                if (servers != null && servers.Count != 0)
                {
                    gameServerDataGrid.ItemsSource = servers;
                    loadingLabelAllServers.Visibility = Visibility.Hidden;
                }
                else
                {
                    loadingLabelAllServers.Text = "Failed to retrieve servers.";
                }
            });
        }
        catch (Exception ex)
        {
            Trace.WriteLine($"Error updating server list: {ex.Message}");
            loadingLabelAllServers.Text = "Failed to retrieve servers.";
        }
    }

    private async void RefreshItem_Click(object sender, RoutedEventArgs e)
    {
        await UpdateServerList();
    }

    private async void GameServerDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        var selectedServer = (Server)gameServerDataGrid.SelectedItem;

        if (selectedServer == null)
        {
            playersTabDataGrid.ItemsSource = null;
            loadingLabelPlayers.Text = "Failed to retrieve players.";
            loadingLabelPlayers.Visibility = Visibility.Visible;
            return;
        }

        await Dispatcher.InvokeAsync(() =>
        {
            playersTabDataGrid.ItemsSource = null;
            loadingLabelPlayers.Text = "Loading...";
            loadingLabelPlayers.Visibility = Visibility.Visible;
        });

        try
        {
            var players = await SAMPQuery.GetPlayersAsync(selectedServer.IpAddr).ConfigureAwait(false);

            await Dispatcher.InvokeAsync(() =>
            {
                if (players != null && players.Count != 0)
                {
                    playersTabDataGrid.ItemsSource = players;
                    loadingLabelPlayers.Visibility = Visibility.Hidden;
                }
                else
                {
                    loadingLabelPlayers.Text = "Failed to retrieve players.";
                }
            });
        }
        catch (Exception ex)
        {
            Trace.WriteLine($"Error updating player list: {ex.Message}");
            loadingLabelPlayers.Text = "Failed to retrieve players.";
        }
    }
}