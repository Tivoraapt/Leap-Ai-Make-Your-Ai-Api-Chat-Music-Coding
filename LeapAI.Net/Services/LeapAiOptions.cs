namespace LeapAI.Net.SDK.Services
{
    public class LeapAiOptions
    {
        private const string LeapAiDefaultApiVersion = "v1";
        private const string LeapAiDefaultBaseDomain = "https://api.tryleap.ai/";

        /// <summary>
        /// The LeapAI API uses AiKey for authentication. You can find your ApiKey within your LeapAI
        /// <a href="https://www.tryleap.ai/projects/">project page</a>. It will be in the format of
        /// a GUID (e.g. 00000000-0000-0000-0000-000000000000).
        /// Remember that your API key is a secret! Do not share it with others or expose it in any client-side code(browsers,
        /// apps). Production requests must be routed through your own backend server where your API key can be securely loaded
        /// from an environment variable or key management service.
        /// </summary>
        public string ApiKey { get; set; } = null!;

        /// <summary>
        /// The base domain for the LeapAI API.This defaults to https://api.tryleap.ai/ but can be changed.
        /// </summary>
        public string BaseDomain { get; set; } = LeapAiDefaultBaseDomain;

        /// <summary>
        /// The version of the LeapAI API to use. This defaults to v1 but can be changed.
        /// </summary>
        public string ApiVersion { get; set; } = LeapAiDefaultApiVersion;

        /// <summary>
        /// Whether or not to validate the ApiOptions. This defaults to true but can be changed.
        /// </summary>
        public bool ValidateApiOptions { get; set; } = true;

        /// <summary>
        /// The default model ID to use for requests. This defaults to null but can be changed.
        /// Use the PreTrainedModels class to get the model ID for a pre-trained model.
        /// </summary>
        public string? DefaultModelId { get; set; }

        /// <summary>
        /// Validate Settings
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public void Validate()
        {
            if (!ValidateApiOptions)
            {
                return;
            }

            if (string.IsNullOrEmpty(ApiKey))
            {
                throw new ArgumentNullException(nameof(ApiKey));
            }

            if (string.IsNullOrEmpty(ApiVersion))
            {
                throw new ArgumentNullException(nameof(ApiVersion));
            }

            if (string.IsNullOrEmpty(BaseDomain))
            {
                throw new ArgumentNullException(nameof(BaseDomain));
            }
        }
    }
}
