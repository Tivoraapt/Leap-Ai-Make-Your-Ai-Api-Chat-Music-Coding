using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels
{
    public record ImageData
    {
        /// <summary>
        /// Empty constructor required by some serializers.
        /// </summary>
        public ImageData()
        { }

        /// <summary>
        /// The id of the image
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The uri of the image
        /// </summary>
        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        /// <summary>
        /// When the image was created
        /// </summary>
        /// <example>
        /// Here is an example value that could be returned:
        /// "2023-04-21T13:04:21.185Z"
        /// </example>
        [JsonPropertyName("createdAt")]
        public string? CreatedAt { get; set; }
    }
}
