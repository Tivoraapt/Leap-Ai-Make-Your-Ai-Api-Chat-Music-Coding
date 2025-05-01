using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels
{
    public record WeightsData
    {
        /// <summary>
        /// The Uri of the weights
        /// </summary>
        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        /// <summary>
        /// The ID of the weights
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
}
