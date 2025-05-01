using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels.RequestModels
{
    public record ImageJobCreateRequest
    {
        /// <summary>
        /// Empty constructor required by some serializers.
        /// </summary>
        public ImageJobCreateRequest()
        { }

        /// <summary>
        /// Constructor for the image create request
        /// </summary>
        /// <param name="prompt">The prompt to use for image creation</param>
        /// <example>
        /// Here is an example of how to use this constructor:
        /// <code>
        /// var request = new ImageCreateRequest("A cat");
        /// </code>
        /// </example>
        public ImageJobCreateRequest(string prompt)
        {
            Prompt = prompt;
        }
        
        /// <summary>
        /// The prompt to use for image creation
        /// </summary>
        [JsonPropertyName("prompt")]
        public string? Prompt { get; set; }

        /// <summary>
        /// Things you want to avoid in the image
        /// </summary>
        [JsonPropertyName("negativePrompt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NegativePrompt { get; set; }

        /// <summary>
        /// The version of the model to use for the inference. 
        /// If not provided will default to latest.
        /// </summary>
        [JsonPropertyName("version")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Version { get; set; }

        /// <summary>
        /// The number of steps to take when creating the image. 
        /// Must be no more than 100.
        /// </summary>
        [JsonPropertyName("steps")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Steps { get; set; }

        /// <summary>
        /// The width of the image to use for the inference. 
        /// Must be a multiple of 8 less than or equal to 1024.
        /// </summary>
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Width { get; set; }

        /// <summary>
        /// The height of the image to use for the inference. 
        /// Must be a multiple of 8 less than or equal to 1024.
        /// </summary>
        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Height { get; set; }

        /// <summary>
        /// The number of images to generate for the inference. 
        /// Must be no larger than 4.
        /// </summary>
        [JsonPropertyName("numberOfImages")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? NumberOfImages { get; set; }

        /// <summary>
        /// The higher the prompt strength, the closer the 
        /// generated image will be to the prompt. Must be 
        /// between 0 and 30.
        /// </summary>
        [JsonPropertyName("promptStrength")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PromptStrength { get; set; }

        /// <summary>
        /// The seed to use for the inference. 
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
        /// Optionally apply face restoration to the 
        /// generated images. This will make images 
        /// of faces look more realistic.
        /// </summary>
        [JsonPropertyName("restoreFaces")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RestoreFaces { get; set; }

        /// <summary>
        /// Optionally enhance your prompts automatically 
        /// to generate better results.
        /// </summary>
        [JsonPropertyName("enhancePrompt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? EnhancePrompt { get; set; }

        /// <summary>
        /// Optionally upscale the generated images. 
        /// This will make the images look more realistic. 
        /// The default is x1, which means no upscaling. 
        /// The maximum is x4.
        /// </summary>
        [JsonPropertyName("upscaleBy")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UpscaleBy { get; set; }

        /// <summary>
        /// Choose the sampler used for your inference.
        /// </summary>
        [JsonPropertyName("sampler")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Sampler { get; set; }
    }
}
