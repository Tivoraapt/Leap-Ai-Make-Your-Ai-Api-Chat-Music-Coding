using LeapAI.Net.SDK.ObjectModels.Interfaces;
using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels.ResponseModels
{
    public record ImageSampleResponse : IImageSample
    {
        /// <summary>
        /// Empty constructor required by some serializers.
        /// </summary>
        public ImageSampleResponse()
        { }

        /// <summary>
        /// The ID of the sample
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// When the sample was created
        /// </summary>
        /// <example>
        /// Here is an example value that could be returned:
        /// "2023-04-21T13:04:21.185Z"
        /// </example>
        [JsonPropertyName("createdAt")]
        public string? CreatedAt { get; set; }

        /// <summary>
        /// The URI of the sample
        /// </summary>
        [JsonPropertyName("uri")]
        public string? Uri { get; set; }
    }
}
