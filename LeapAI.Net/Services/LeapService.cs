using LeapAI.Net.SDK.EndpointProviders;
using LeapAI.Net.SDK.Interfaces;

namespace LeapAI.Net.SDK.Services
{
    public abstract class LeapService
    {
        internal readonly ILeapAiEndpointProvider _endpointProvider;
        internal readonly HttpClient _httpClient;
        
        private string? _defaultModelId;

        /// <summary>
        /// Default constructor for the LeapService.
        /// </summary>
        /// <param name="options">Options to use for the service</param>
        /// <param name="client">Http client to use for the service</param>
        public LeapService(LeapAiOptions options, HttpClient? client = null)
        {
            options.Validate();

            _httpClient = client ?? new HttpClient();
            _httpClient.BaseAddress = new Uri(options.BaseDomain);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.ApiKey}");
            _endpointProvider = new LeapAiEndpointProvider(options.ApiVersion);
            
            DefaultModelId = options.DefaultModelId;
        }

        /// <summary>
        /// Manage the default model ID to use for requests.
        /// </summary>
        public string? DefaultModelId
        {
            get => _defaultModelId;
            set => _defaultModelId = value;
        }
    }
}
