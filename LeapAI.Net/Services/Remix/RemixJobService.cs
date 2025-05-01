using LeapAI.Net.SDK.Interfaces;
using LeapAI.Net.SDK.ObjectModels.RequestModels;
using LeapAI.Net.SDK.ObjectModels.ResponseModels;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Net.Http.Headers;
using System.Reflection;

namespace LeapAI.Net.SDK.Services.Image
{
    public class RemixJobService : LeapService, IRemixJobService
    {
        public RemixJobService(LeapAiOptions options, HttpClient? client = null) 
            : base(options, client)
        { }

        /// <summary>
        /// Creates a remix job based on the given request
        /// </summary>
        /// <param name="request">The request containing the parameters for remix creation</param>
        /// <param name="pathToFile">The path to the file to use for the remix</param>
        /// <param name="modelId">An optional model for this remix job to override the default</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>A RemixJobCreateResponse object containing details of the job</returns>
        /// <remarks>If no model ID is provided in the request, the default will be used</remarks>
        /// <exception cref="ArgumentException">Occurs if no model ID was provided
        /// and no default model ID has been set or if no file path has been provided or 
        /// if the provided path doesn't exist. Will also occur if the requested number of images is 
        /// greater than 4 or if the requested number of steps is greater than 100</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<RemixJobCreateResponse> CreateRemixJobFromFileAsync(RemixJobCreateRequest request, 
            string pathToFile, string? modelId = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(DefaultModelId) && string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");
            if (string.IsNullOrEmpty(pathToFile))
                throw new ArgumentException("No file path was provided in the request.");
            if (!File.Exists(pathToFile))
                throw new ArgumentException("The file path provided does not exist.");
            if (request.NumberOfImages > 4)
                throw new ArgumentException("The maximum number of images is 4.");
            if (request.Steps > 100)
                throw new ArgumentException("The maximum number of steps is 100.");

            var chosenModel = modelId ?? DefaultModelId;
            var formData = new MultipartFormDataContent();

            foreach (var prop in request.GetType().GetProperties())
            {
                var value = prop.GetValue(request);

                if (value != null)
                {
                    // Retrieve the JsonPropertyName attribute value
                    var attribute = prop.GetCustomAttribute<JsonPropertyNameAttribute>();
                    var jsonPropertyName = attribute?.Name ?? prop.Name;
                    var content = new StringContent(value.ToString(), Encoding.UTF8);

                    formData.Add(content, jsonPropertyName);
                }
            }

            var extension = Path.GetExtension(pathToFile).Replace(".", "");
            var fileBytes = File.ReadAllBytes(pathToFile);
            var fileContent = new ByteArrayContent(fileBytes);

            fileContent.Headers.ContentType = new MediaTypeHeaderValue($"image/{extension}");
            formData.Add(fileContent, "files", Path.GetFileName(pathToFile));

            var response = await _httpClient.PostAsync(_endpointProvider.RemixJobUsingFileCreate(chosenModel),
                formData, cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<RemixJobCreateResponse>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Creates a remix job based on the given request
        /// </summary>
        /// <param name="request">The request containing the parameters for remix creation</param>
        /// <param name="modelId">An optional model for this remix job to override the default</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>A RemixJobCreateResponse object containing details of the job</returns>
        /// <remarks>If no model ID is provided in the request, the default will be used</remarks>
        /// <exception cref="ArgumentException">Occurs if no model ID was provided in the request
        /// and no default model ID has been set or if no image URL was provided. Will also occur if 
        /// the requested number of images is greater than 4 or if the requested number of steps is 
        /// greater than 100</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<RemixJobCreateResponse> CreateRemixJobFromUrlAsync(RemixJobCreateRequest request, 
            string? modelId = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(DefaultModelId) && string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");
            if (string.IsNullOrEmpty(request.ImageUrl))
                throw new ArgumentException("No image URL was provided in the request.");
            if (request.NumberOfImages > 4)
                throw new ArgumentException("The maximum number of images is 4.");
            if (request.Steps > 100)
                throw new ArgumentException("The maximum number of steps is 100.");

            var chosenModel = modelId ?? DefaultModelId;
            var response = await _httpClient.PostAsJsonAsync(_endpointProvider.RemixJobUsingUrlCreate(chosenModel),
                request, cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<RemixJobCreateResponse>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Gets a remix job for the given model ID and job inference ID
        /// </summary>
        /// <param name="modelId">The model ID to get images for</param>
        /// <param name="remixId">The remix ID to retrieve</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>A RemixJobResponse object detailing the job</returns>
        /// <exception cref="ArgumentException">Occurs if no model or job inference IDs are provided</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<RemixJobResponse> GetRemixJobAsync(string modelId, string remixId, 
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(DefaultModelId) && string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");
            if (string.IsNullOrEmpty(modelId))
                modelId = DefaultModelId;
            if (string.IsNullOrEmpty(remixId))
                throw new ArgumentException("No remix job ID was provided in the request.");

            var response = await _httpClient.GetAsync(_endpointProvider.RemixJobGet(modelId, remixId), 
                cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<RemixJobResponse>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }
    }
}
