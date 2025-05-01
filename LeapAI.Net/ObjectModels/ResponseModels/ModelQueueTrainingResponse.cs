using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels.ResponseModels
{
    public record ModelQueueTrainingResponse
    {
        /// <summary>
        /// Empty constructor required by some serializers.
        /// </summary>
        public ModelQueueTrainingResponse()
        { }

        /// <summary>
        /// The ID of the model training job
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// When the training job was created
        /// </summary>
        /// <example>
        /// Here is an example value that could be returned:
        /// "2023-04-21T13:04:21.185Z"
        /// </example>
        [JsonPropertyName("createdAt")]
        public string? CreatedAt { get; set; }

        /// <summary>
        /// The status of the model training job
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// The model that will be trained
        /// </summary>
        [JsonPropertyName("model")]
        public ModelResponse? Model { get; set; }

        /// <summary>
        /// The weights data for the training job
        /// </summary>
        [JsonPropertyName("weights")]
        public WeightsData? Weights { get; set; }

        /// <summary>
        /// The number of steps to take when training the model
        /// </summary>
        [JsonPropertyName("steps")]
        public int? Steps { get; set; }
    }
}
