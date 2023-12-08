using System.Text.Json.Serialization;

namespace SAMP.API
{
    /// <summary>
    /// This class is storing the Players data in SAMP server. Data can be accessed by providing ip address. 
    /// Example: <see href="https://sam.markski.ar/api/GetServerPlayers?ip_addr=51.68.204.178:7777"/>
    /// </summary>
    public class Players
    {
        /// <summary>
        /// Player ID of the player in server. 
        /// </summary>
        [JsonPropertyName("id")]
        public int PlayerID { get; set; }

        /// <summary>
        /// Current player ping. 
        /// </summary>
        [JsonPropertyName("ping")]
        public int Ping { get; set; } = 0;

        /// <summary>
        /// Current player nickname. 
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = "Unknown_Player";

        /// <summary>
        /// Current player score.
        /// </summary>
        [JsonPropertyName("score")]
        public int Score { get; set; } = 0; 
    }
}