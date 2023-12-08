using System.Diagnostics;
using System.Text.Json;

namespace SAMP.API
{
    /// <summary>
    /// A static SAMP Query class that allows the developer access API functions from <see href="http://sam.markski.ar/api"/> site, to get full info about API that I'm using here is the Git page of this API: <see href="https://github.com/markski1/SAMonitor"/> 
    /// </summary>
    public static class SAMPQuery
    {
        /// <summary>
        /// Function that does query to <see href="http://sam.markski.ar/api/GetAllServers"/> gets the json string, converts all data to Server class.
        /// </summary>
        /// <returns>full list of servers from SAMP launcher</returns>
        public static async Task<List<Server>?> GetServersAsync()
        {
            using HttpClient client = new();
            try
            {
                HttpResponseMessage response = await client.GetAsync(Utils.LINK_GETALLSERVERS);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<Server>>(json);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Function that with given ipAddress queries to <see href="https://sam.markski.ar/api/GetServerPlayers?ip_addr="/>
        /// it retrives the current players that is playing on that server. Keep also please in mind some servers that have
        /// big amount of players it can simply return nothing as result (api of site will give the empty json)
        /// It will not throw any exception, just if you want to check if you have no players you can simply create visual that will say
        /// 'Couldn't not retrive player data' or whatever. 
        /// </summary>
        /// <param name="ipAddress">ipAddress of the server</param>
        /// <returns>list of all players that are playing on server.</returns>
        public static async Task<List<Players>?> GetPlayersAsync(string ipAddress)
        {
            using HttpClient client = new();
            try
            {
                HttpResponseMessage response = await client.GetAsync(Utils.LINK_GETSERVERPLAYERS + ipAddress);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<Players>>(json);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return null;
            }
        }
    }
}