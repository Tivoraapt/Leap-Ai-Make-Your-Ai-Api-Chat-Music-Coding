using System.Text.Json.Serialization;

namespace LeapAI.Net.SDK.ObjectModels.ResponseModels
{
    public record ModelObjectResponse
    {

        /// <summary>
        /// Data contained in the response
        /// </summary>
        [JsonPropertyName("data")]
        public ModelResponse[]? Data { get; set; }
    }
}
