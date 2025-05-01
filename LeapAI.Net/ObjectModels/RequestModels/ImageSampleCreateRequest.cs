using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels.RequestModels
{
    public record ImageSampleCreateRequest
    {
        /// <summary>
        /// Empty constructor required by some serializers.
        /// </summary>
        public ImageSampleCreateRequest()
        { }

        /// <summary>
        /// The URL(s) to the image(s) to use for the sample
        /// </summary>
        [JsonPropertyName("images")]
        public string[]? Images { get; set; }
    }
}
