using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels.RequestModels
{
    public record RemixJobCreateRequest
    {
        /// <summary>
        /// Empty constructor required by some serializers.
        /// </summary>
        public RemixJobCreateRequest()
        { }

        /// <summary>
        /// Constructor for the remix job create request
        /// </summary>
        /// <param name="prompt">The prompt to use for remix creation</param>
        /// <example>
        /// Here is an example of how to use this constructor:
        /// <code>
        /// var request = new RemixJobCreateRequest("A cat", "cat.png");
        /// </code>
        /// </example>
        public RemixJobCreateRequest(string prompt)
        {
            Prompt = prompt;
        }

        /// <summary>
        /// The prompt to use for remix creation
        /// </summary>
        [JsonPropertyName("prompt")]
        public string? Prompt { get; set; }

        /// <summary>
        /// The URL to the image to use for the remix
        /// </summary>
        [JsonPropertyName("imageUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Things you want to avoid in the remix
        /// </summary>
        [JsonPropertyName("negativePrompt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NegativePrompt { get; set; }

        /// <summary>
        /// The number of steps to take when creating the remix. 
        /// Must be no more than 100.
        /// </summary>
        [JsonPropertyName("steps")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Steps { get; set; }

        /// <summary>
        /// The seed to use for the remix. 
        /// Must be a positive integer.
        /// </summary>
        [JsonPropertyName("seed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong? Seed { get; set; }

        /// <summary>
        /// An optional webhook URL that will be called 
        /// when the job is complete.
        /// </summary>
        [JsonPropertyName("webhookUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? WebhookUrl { get; set; }

        /// <summary>
        /// The number of images to generate for the remix. 
        /// Must be no larger than 4.
        /// </summary>
        [JsonPropertyName("numberOfImages")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? NumberOfImages { get; set; }

        /// <summary>
        /// The segmentation mode that should be used 
        /// when generating the remix.
        /// </summary>
        [JsonPropertyName("mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Mode { get; set; }
    }
}
