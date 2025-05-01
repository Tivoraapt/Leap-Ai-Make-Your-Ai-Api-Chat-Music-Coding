using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels.ResponseModels
{
    public record ImageJobCreateResponse
    {
        /// <summary>
        /// Empty constructor required by some serializers.
        /// </summary>
        public ImageJobCreateResponse()
        { }

        /// <summary>
        /// The status of the image creation
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// The ID of the image creation job
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The prompt used for image creation
        /// </summary>
        [JsonPropertyName("prompt")]
        public string? Prompt { get; set; }

        /// <summary>
        /// Things you want to avoid in the image
        /// </summary>
        [JsonPropertyName("negativePrompt")]
        public string? NegativePrompt { get; set; }

        /// <summary>
        /// The seed used for the inference.
        /// </summary>
        [JsonPropertyName("seed")]
        public ulong? Seed { get; set; }

        /// <summary>
        /// The width of the image
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// The height of the image
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }

        /// <summary>
        /// The number of images created with this job
        /// </summary>
        [JsonPropertyName("numberOfImages")]
        public int? NumberOfImages { get; set; }

        /// <summary>
        /// The number of steps taken when creating the image
        /// </summary>
        [JsonPropertyName("steps")]
        public int? Steps { get; set; }

        /// <summary>
        /// When the image was created
        /// </summary>
        /// <example>
        /// Here is an example value that could be returned:
        /// "2023-04-21T13:04:21.185Z"
        /// </example>
        [JsonPropertyName("createdAt")]
        public string? CreatedAt { get; set; }

        /// <summary>
        /// The prompt strength used for image creation
        /// </summary>
        [JsonPropertyName("promptStrength")]
        public int? PromptStrength { get; set; }

        /// <summary>
        /// Any images created
        /// </summary>
        [JsonPropertyName("images")]
        public ImageData[]? Images { get; set; }

        /// <summary>
        /// The ID of the model used for this image creation job
        /// </summary>
        [JsonPropertyName("modelId")]
        public string? ModelId { get; set; }

        /// <summary>
        /// The upscaling option used for this image creation job
        /// </summary>
        [JsonPropertyName("upscalingOption")]
        public string? UpscalingOption { get; set; }

        /// <summary>
        /// The sampler used for this image creation job
        /// </summary>
        [JsonPropertyName("sampler")]
        public string? Sampler { get; set; }
    }
}
