using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels.RequestModels
{
    public record ModelCreateRequest
    {
        /// <summary>
        /// Empty constructor required by some serializers.
        /// </summary>
        public ModelCreateRequest()
        { }

        /// <summary>
        /// Constructor for the model create request
        /// </summary>
        /// <param name="title">The name of the new model</param>
        /// <param name="subjectKeyword">The model's subject keyword</param>
        /// <example>
        /// Here is an example of how to use this constructor:
        /// <code>
        /// var request = new ModelCreateRequest("Cat Model", "@me");
        /// </code>
        /// </example>
        public ModelCreateRequest(string title, string subjectKeyword)
        {
            Title = title;
            SubjectKeyword = subjectKeyword;
        }

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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SubjectIdentifier { get; set; }

        /// <summary>
        /// The subject type - what the underlying model is learning. 
        /// Defaults to "person."
        /// </summary>
        /// <remarks>Use the StaticValues.ModelTypes class</remarks>
        [JsonPropertyName("subjectType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SubjectType { get; set; }
    }
}
