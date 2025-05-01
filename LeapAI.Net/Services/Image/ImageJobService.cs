using LeapAI.Net.SDK.Interfaces;
using LeapAI.Net.SDK.ObjectModels.RequestModels;
using LeapAI.Net.SDK.ObjectModels.ResponseModels;
using System.Net.Http.Json;

namespace LeapAI.Net.SDK.Services.Image
{
    public class ImageJobService : LeapService, IImageJobService
    {
        public ImageJobService(LeapAiOptions options, HttpClient? client = null) 
            : base(options, client)
        { }

        /// <summary>
        /// Creates an image job based on the given request
        /// </summary>
        /// <param name="request">The request containing the parameters for image creation</param>
        /// <param name="modelId">An optional model for this remix job to override the default</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>An ImageJobCreateResponse object containing details of the job</returns>
        /// <remarks>If no model ID is provided in the request, the default will be used</remarks>
        /// <exception cref="ArgumentException">Occurs if no model ID was provided in the request
        /// and no default model ID has been set. Will also occur if the requested number of images is 
        /// greater than 4 or if the requested number of steps is greater than 100</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ImageJobCreateResponse> CreateImageJobAsync(ImageJobCreateRequest request, 
            string? modelId = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(DefaultModelId) && string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");
            if (request.NumberOfImages > 4)
                throw new ArgumentException("The maximum number of images is 4.");
            if (request.Steps > 100)
                throw new ArgumentException("The maximum number of steps is 100.");

            var chosenModel = modelId ?? DefaultModelId;
            var response = await _httpClient.PostAsJsonAsync(_endpointProvider.ImageJobCreate(chosenModel),
                request, cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ImageJobCreateResponse>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Gets all job inferences for the given model ID
        /// </summary>
        /// <param name="modelId">The model ID to get images for</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>An array of ImageJobCreateResponse objects representing 
        /// the jobs for the given model meeting the provided criteria</returns>
        /// <remarks>If no model ID is provided, the default will be used</remarks>
        /// <exception cref="ArgumentException">Occurs if no model ID was provided in the request
        /// and no default model ID has been set</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ImageJobCreateResponse[]> GetImageJobsAsync(string modelId, 
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(DefaultModelId) && string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided in the request or as a default.");
            if (string.IsNullOrEmpty(modelId))
                modelId = DefaultModelId;

            var response = await _httpClient.GetAsync(_endpointProvider.ImageJobsGet(modelId), 
                cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content
                    .ReadFromJsonAsync<ImageJobCreateResponse[]>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Gets a job for the given model ID and job inference ID
        /// </summary>
        /// <param name="modelId">The model ID to get images for</param>
        /// <param name="jobInferenceId">The Job Inference ID to retrieve</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>An ImageJobResponse object detailing the job</returns>
        /// <exception cref="ArgumentException">Occurs if no model or job inference IDs are provided</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ImageJobResponse> GetImageJobAsync(string modelId, string jobInferenceId, 
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(DefaultModelId) && string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided in the request or as a default.");
            if (string.IsNullOrEmpty(modelId))
                modelId = DefaultModelId;
            if (string.IsNullOrEmpty(jobInferenceId))
                throw new ArgumentException("No job inference ID was provided in the request.");

            var response = await _httpClient.GetAsync(_endpointProvider.ImageJobGet(modelId, jobInferenceId), 
                cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ImageJobResponse>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Deletes the job for the given model ID and inference ID
        /// </summary>
        /// <param name="modelId">The model ID to find jobs for</param>
        /// <param name="jobInferenceId">The ID of the job to delete</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>An empty string if successful, the Http status code otherwise</returns>
        /// <exception cref="ArgumentException">Occurs if no model or job inference IDs are provided</exception>
        public async Task<string> DeleteImageJobAsync(string modelId, string jobInferenceId, 
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(DefaultModelId) && string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided in the request or as a default.");
            if (string.IsNullOrEmpty(modelId))
                modelId = DefaultModelId;
            if (string.IsNullOrEmpty(jobInferenceId))
                throw new ArgumentException("No job inference ID was provided in the request.");

            var response = await _httpClient.DeleteAsync(_endpointProvider.ImageJobDelete(modelId, jobInferenceId),
                cancellationToken);

            if (response.IsSuccessStatusCode)
                return "";
            else
                return $"{response.StatusCode}";
        }
    }
}
