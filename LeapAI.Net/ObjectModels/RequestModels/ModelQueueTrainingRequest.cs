using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels.RequestModels
{
    public record ModelQueueTrainingRequest
    {
        /// <summary>
        /// Empty constructor required by some serializers.
        /// </summary>
        public ModelQueueTrainingRequest()
        { }

        /// <summary>
        /// An optional webhook URL that will be called 
        /// when the job is complete.
        /// </summary>
        [JsonPropertyName("webhookUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? WebhookUrl { get; set; }

        /// <summary>
        /// The ID of the weights to use for training - 
        /// defaults to Stable Diffusion v1.5 weights. 
        /// Check the pretrained models page for a list 
        /// of available weights.
        /// </summary>
        /// <remarks>Use the PretrainedModels static class</remarks>
        [JsonPropertyName("baseWeightsId")]
        public string? BaseWeightsId { get; set; }

        /// <summary>
        /// The number of steps your model will be trained for. 
        /// By default, this is set to 100 * the number of samples 
        /// you provided. Must not be less than 50.
        [JsonPropertyName("steps")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Steps { get; set; }
    }
}
