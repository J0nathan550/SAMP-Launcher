using System.Text.Json.Serialization;

namespace SAMP.API
{
    /// <summary>
    /// Server class - holds the JSON properties from the <see href="http://sam.markski.ar/api/GetAllServers"/>
    /// </summary>
    public class Server
    {
        /// <summary>
        /// ID of server in SAMP
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Is server is alive? 
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Last updated statistics from the API
        /// </summary>
        [JsonPropertyName("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Server World time
        /// </summary>
        [JsonPropertyName("worldTime")]
        public DateTime WorldTime { get; set; }

        /// <summary>
        /// Current player count on the server
        /// </summary>
        [JsonPropertyName("playersOnline")]
        public int PlayersOnline { get; set; }

        /// <summary>
        /// Maximum capacity of players available on the server
        /// </summary>
        [JsonPropertyName("maxPlayers")]
        public int MaxPlayers { get; set; }

        /// <summary>
        /// Is server using OpenMP server
        /// </summary>
        [JsonPropertyName("isOpenMp")]
        public bool IsOpenMp { get; set; }

        /// <summary>
        /// Is server uses Lag Compensation
        /// </summary>
        [JsonPropertyName("lagComp")]
        public bool LagComp { get; set; }

        /// <summary>
        /// Hostname of the server
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = "Unknown Server Name";

        /// <summary>
        /// Gamemode of the server
        /// </summary>
        [JsonPropertyName("gameMode")]
        public string GameMode { get; set; } = "Unknown Gamemode Name";

        /// <summary>
        /// IPAddress of the server
        /// </summary>
        [JsonPropertyName("ipAddr")]
        public string IpAddr { get; set; } = "0.0.0.0";

        /// <summary>
        /// Map name of the server
        /// </summary>
        [JsonPropertyName("mapName")]
        public string MapName { get; set; } = "San Andreas";

        /// <summary>
        /// Website of the server
        /// </summary>
        [JsonPropertyName("website")]
        public string Website { get; set; } = "https://www.open.mp";

        /// <summary>
        /// What kind of version this server require to play, usually 0.3.7 (latest)
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; } = "0.3.7";

        /// <summary>
        /// Language of the server
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; } = "English";

        /// <summary>
        /// (Version of SAMPCAC required. "Not required" otherwise.) this information I got from original github page. <see href="https://github.com/markski1/SAMonitor"/>
        /// </summary>
        [JsonPropertyName("sampCac")]
        public string SampCac { get; set; } = "Not required.";

        /// <summary>
        /// Is server has a password?
        /// </summary>
        [JsonPropertyName("requiresPassword")]
        public bool RequiresPassword { get; set; }

        /// <summary>
        /// Custom ping variable not included in API (well of course how can you get PING in API when you literally have to calculate it? :D)
        /// </summary>
        public string Ping
        {
            get; set;
            //get
            //{
            //    try
            //    {
            //        Ping myPing = new();
            //        int colonIndex = IpAddr.IndexOf(':');
            //        string ipAddressWithoutPort = string.Empty;
            //        if (colonIndex != -1) ipAddressWithoutPort = IpAddr[..colonIndex];
            //        PingReply reply = myPing.Send(ipAddressWithoutPort, 1000);
            //        return reply.RoundtripTime.ToString();
            //    }
            //    catch(Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        return "timeout";
            //    }
            //}
        } = "Timeout";
    }
}