using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels.ResponseModels
{
    public record ModelVersionResponse
    {
        /// <summary>
        /// Empty constructor required by some serializers.
        /// </summary>
        public ModelVersionResponse()
        { }

        /// <summary>
        /// The ID of the model version
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// When the model version was created
        /// </summary>
        /// <example>
        /// Here is an example value that could be returned:
        /// "2023-04-21T13:04:21.185Z"
        /// </example>
        [JsonPropertyName("createdAt")]
        public string? CreatedAt { get; set; }

        /// <summary>
        /// The status of the model version
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// The model version data
        /// </summary>
        [JsonPropertyName("model")]
        public ModelResponse? Model { get; set; }

        /// <summary>
        /// The weights data for the model version
        /// </summary>
        [JsonPropertyName("weights")]
        public WeightsData? Weights { get; set; }

        /// <summary>
        /// The number of steps taken when training the model version
        /// </summary>
        [JsonPropertyName("steps")]
        public int? Steps { get; set; }
    }
}
