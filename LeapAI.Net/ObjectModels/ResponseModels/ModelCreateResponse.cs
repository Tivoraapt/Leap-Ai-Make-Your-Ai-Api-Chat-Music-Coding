using LeapAI.Net.SDK.ObjectModels.Interfaces;
using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels.ResponseModels
{
    public record ModelCreateResponse : IModel
    {
        /// <summary>
        /// Empty constructor required by some serializers.
        /// </summary>
        public ModelCreateResponse()
        { }

        /// <summary>
        /// The ID of the model creation job
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The name of the model
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// The subject keyword used during inference to trigger 
        /// specific styles
        /// </summary>
        [JsonPropertyName("subjectKeyword")]
        public string? SubjectKeyword { get; set; }

        /// <summary>
        /// A random string that will replace the subject keyword 
        /// at the time of inference. If not provided, a random 
        /// string will be automatically generated.
        /// </summary>
        [JsonPropertyName("subjectIdentifier")]
        public string? SubjectIdentifier { get; set; }
    }
}
