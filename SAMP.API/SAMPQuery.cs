using System.Net.NetworkInformation;
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
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}