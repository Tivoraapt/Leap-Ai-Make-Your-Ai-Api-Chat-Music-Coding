using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels.ResponseModels
{
    public record RemixJobCreateResponse
    {
        /// <summary>
        /// Empty constructor required by some serializers.
        /// </summary>
        public RemixJobCreateResponse()
        { }

        /// <summary>
        /// The web address to the image used for the remix
        /// </summary>
        [JsonPropertyName("sourceImageUri")]
        public string? SourceImageUri { get; set; }

        /// <summary>
        /// The ID of the remix creation job
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// When the remix job was created
        /// </summary>
        /// <example>
        /// Here is an example value that could be returned:
        /// "2023-04-21T13:04:21.185Z"
        /// </example>
        [JsonPropertyName("createdAt")]
        public string? CreatedAt { get; set; }

        /// <summary>
        /// The prompt used for remix creation
        /// </summary>
        [JsonPropertyName("prompt")]
        public string? Prompt { get; set; }

        /// <summary>
        /// The status of the remix creation job
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// The number of steps taken when creating the remix
        /// </summary>
        [JsonPropertyName("steps")]
        public int? Steps { get; set; }

        /// <summary>
        /// The ID of the project used for this remix creation job
        /// </summary>
        [JsonPropertyName("projectId")]
        public string? ProjectId { get; set; }

        /// <summary>
        /// The seed used for the remix.
        /// </summary>
        [JsonPropertyName("seed")]
        public ulong? Seed { get; set; }

        /// <summary>
        /// Things you want to avoid in the remix
        /// </summary>
        [JsonPropertyName("negativePrompt")]
        public string? NegativePrompt { get; set; }

        /// <summary>
        /// The number of remixes created with this job
        /// </summary>
        [JsonPropertyName("numberOfImages")]
        public int? NumberOfImages { get; set; }

        /// <summary>
        /// The ID of the model used for this remix creation job
        /// </summary>
        [JsonPropertyName("modelId")]
        public string? ModelId { get; set; }

        /// <summary>
        /// The mode used for this remix creation job
        /// </summary>
        [JsonPropertyName("mode")]
        public string? Mode { get; set; }
    }
}
