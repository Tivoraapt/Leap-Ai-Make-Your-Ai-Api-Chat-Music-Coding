using LeapAI.Net.SDK.Interfaces;
using LeapAI.Net.SDK.ObjectModels.RequestModels;
using LeapAI.Net.SDK.ObjectModels.ResponseModels;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace LeapAI.Net.SDK.Services.Image
{
    public class ModelFineTuningService : LeapService, IModelFineTuningService
    {
        public ModelFineTuningService(LeapAiOptions options, HttpClient? client = null) 
            : base(options, client)
        { }

        /// <summary>
        /// Archives a given image sample for a given model
        /// </summary>
        /// <param name="modelId">A model ID to archive an image sample for</param>
        /// <param name="sampleId">The sample ID to archive</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>An ImageSampleArchiveResponse object</returns>
        /// <exception cref="ArgumentException">Occurs if no model ID or sample ID was provided</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ImageSampleArchiveResponse> ArchiveImageSampleAsync(string modelId, 
            string sampleId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");
            if (string.IsNullOrEmpty(sampleId))
                throw new ArgumentException("No sample ID was provided.");

            var response = await _httpClient.PostAsync(_endpointProvider.ImageSampleArchive(modelId, sampleId),
                null, cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ImageSampleArchiveResponse>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Creates a new model
        /// </summary>
        /// <param name="request">Details about the model to create</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>A ModelCreateResponse object</returns>
        /// <exception cref="ArgumentException">Occurs if no model title or subject keyword was provided</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ModelCreateResponse> CreateModelAsync(ModelCreateRequest request, 
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(request.Title))
                throw new ArgumentException("No title was provided.");
            if (string.IsNullOrEmpty(request.SubjectKeyword))
                throw new ArgumentException("No subject keyword was provided.");

            var response = await _httpClient.PostAsJsonAsync(_endpointProvider.ModelCreate(),
                request, cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ModelCreateResponse>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Deletes the model with the given ID
        /// </summary>
        /// <param name="modelId">The ID of the model to delete</param>
        /// <returns>An empty string if successful, the Http status code otherwise</returns>
        /// <exception cref="ArgumentException">Occurs if no model ID is provided</exception>
        public async Task<string> DeleteModelAsync(string modelId, 
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");

            var response = await _httpClient.DeleteAsync(_endpointProvider.ModelDelete(modelId),
                cancellationToken);

            if (response.IsSuccessStatusCode)
                return "";
            else
                return $"{response.StatusCode}";
        }

        /// <summary>
        /// Gets the image sample with the given ID for the given model ID
        /// </summary>
        /// <param name="modelId">The model ID to retrieve samples for</param>
        /// <param name="sampleId">The sample ID to retrieve</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>An ImageSampleResponse object</returns>
        /// <exception cref="ArgumentException">Occurs if no model ID or sample ID was provided</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ImageSampleResponse> GetImageSampleAsync(string modelId, string sampleId, 
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");
            if (string.IsNullOrEmpty(sampleId))
                throw new ArgumentException("No sample ID was provided.");

            var response = await _httpClient.GetAsync(_endpointProvider.ImageSampleGet(modelId, sampleId),
                cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content
                    .ReadFromJsonAsync<ImageSampleResponse>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Retrieves the given version of the given model
        /// </summary>
        /// <param name="modelId">The model ID to retrieve versions for</param>
        /// <param name="versionId">The version ID to retrieve</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>A ModelVersionResponse object</returns>
        /// <exception cref="ArgumentException">Occurs if no model ID or version ID was provided</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ModelVersionResponse> GetModelVersionAsync(string modelId, 
            string versionId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");
            if (string.IsNullOrEmpty(versionId))
                throw new ArgumentException("No version ID was provided.");

            var response = await _httpClient.GetAsync(_endpointProvider.ModelVersionGet(modelId, versionId),
                cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content
                    .ReadFromJsonAsync<ModelVersionResponse>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Get image samples for the given model ID
        /// </summary>
        /// <param name="modelId">The model ID to retrieve image samples for</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>An array of ImageSampleResponse objects</returns>
        /// <exception cref="ArgumentException">Occurs if no model ID was provided</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ImageSampleResponse[]> ListImageSamplesAsync(string modelId, 
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");

            var response = await _httpClient.GetAsync(_endpointProvider.ImageSampleListGet(modelId),
                cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content
                    .ReadFromJsonAsync<ImageSampleResponse[]>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Get available models
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>An array of ModelResponse objects</returns>
        /// <exception cref="ArgumentException">Occurs if no model ID was provided</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ModelResponse[]> ListModelsAsync(CancellationToken cancellationToken = default)
        {
            var endpoint = _endpointProvider.ModelListGet() + "?returnInObject=false";
            var response = await _httpClient.GetAsync(endpoint, cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content
                    .ReadFromJsonAsync<ModelResponse[]>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Get available models returned as a single object
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>A ModelObjectResponse object</returns>
        /// <exception cref="ArgumentException">Occurs if no model ID was provided</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ModelObjectResponse> ListModelsGetObjectAsync(CancellationToken cancellationToken = default)
        {
            var endpoint = _endpointProvider.ModelListGet() + "?returnInObject=true";
            var response = await _httpClient.GetAsync(endpoint, cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content
                    .ReadFromJsonAsync<ModelObjectResponse>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Get versions for the given model ID
        /// </summary>
        /// <param name="modelId">The model ID to retrieve versions for</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>An array of ModelVersionResponse objects</returns>
        /// <exception cref="ArgumentException">Occurs if no model ID was provided</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ModelVersionResponse[]> ListModelVersionsAsync(string modelId, 
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");

            var response = await _httpClient.GetAsync(_endpointProvider.ModelVersionListGet(modelId),
                cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content
                    .ReadFromJsonAsync<ModelVersionResponse[]>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Queue a training job for the model with the given ID
        /// </summary>
        /// <param name="modelId">The model ID to queue a training job for</param>
        /// <param name="request">Details about the model training job</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>A ModelQueueTrainingResponse object</returns>
        /// <exception cref="ArgumentException">Occurs if no model ID was provided 
        /// or if no base weights ID has been provided</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        /// <remarks>
        /// After uploading image samples, you can use this to queue a new model 
        /// version to be trained. Upon completion, you'll be able to query your 
        /// custom model.
        /// NOTE: YOU MUST HAVE ADDED A CREDIT CARD TO YOUR LEAPAI ACCOUNT TO DO THIS. 
        /// </remarks>
        public async Task<ModelQueueTrainingResponse> QueueModelTrainingJobAsync(string modelId, 
            ModelQueueTrainingRequest request, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");
            if (string.IsNullOrEmpty(request.BaseWeightsId))
                throw new ArgumentException("No base weights ID was provided.");

            var response = await _httpClient.PostAsJsonAsync(_endpointProvider.QueueTrainingJob(modelId),
                request, cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ModelQueueTrainingResponse>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Get a model with the given ID
        /// </summary>
        /// <param name="modelId">The model ID to retrieve</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>A ModelResponse object</returns>
        /// <exception cref="ArgumentException">Occurs if no model ID was provided</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ModelResponse> RetrieveModelAsync(string modelId, 
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");

            var response = await _httpClient.GetAsync(_endpointProvider.ModelGet(modelId),
                cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content
                    .ReadFromJsonAsync<ModelResponse>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Uploads a file to the API to be used as an image sample for a model
        /// </summary>
        /// <param name="modelId">A model ID to upload image samples for</param>
        /// <param name="pathToFile">The path to the file to use for the image sample</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>An array of ImageSampleCreateResponse objects</returns>
        /// <exception cref="ArgumentException">Occurs if no model ID was provided 
        /// or if no file path has been provided or if the provided path doesn't exist</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ImageSampleCreateResponse[]> UploadImageSampleFromFileAsync(string modelId, 
            string pathToFile, CancellationToken cancellationToken = default)
        {

            if (string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");
            if (string.IsNullOrEmpty(pathToFile))
                throw new ArgumentException("No file path was provided in the request.");
            if (!File.Exists(pathToFile))
                throw new ArgumentException("The file path provided does not exist.");

            var extension = Path.GetExtension(pathToFile).Replace(".", "");
            var fileBytes = File.ReadAllBytes(pathToFile);
            var fileContent = new ByteArrayContent(fileBytes);
            var fileData = new MultipartFormDataContent();

            fileContent.Headers.ContentType = new MediaTypeHeaderValue($"image/{extension}");
            fileData.Add(fileContent, "files", Path.GetFileName(pathToFile));

            var response = await _httpClient.PostAsync(_endpointProvider.ImageSampleUpload(modelId),
                fileData, cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ImageSampleCreateResponse[]>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }

        /// <summary>
        /// Uploads images via URL to the API to be used as (an) image sample(s) for a model
        /// </summary>
        /// <param name="modelId">A model ID to upload image samples for</param>
        /// <param name="request">The request containing the images to upload</param>
        /// <param name="cancellationToken">An optional cancellation token</param>
        /// <returns>An array of ImageSampleCreateResponse objects</returns>
        /// <exception cref="ArgumentException">Occurs if no model ID was provided</exception>
        /// <exception cref="HttpRequestException">Occurs if the API request fails</exception>
        /// <exception cref="InvalidOperationException">Occurs if the response content is null</exception>
        public async Task<ImageSampleCreateResponse[]> UploadImageSampleFromUrlAsync(string modelId, 
            ImageSampleCreateRequest request, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(modelId))
                throw new ArgumentException("No model ID was provided.");
            if (request.Images == null || !request.Images.Any())
                throw new ArgumentException("No image URLs were provided in the request.");

            var response = await _httpClient.PostAsJsonAsync(_endpointProvider.ImageSampleViaUrlUpload(modelId),
                request, cancellationToken);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ImageSampleCreateResponse[]>(cancellationToken: cancellationToken)
                    ?? throw new InvalidOperationException();

            throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
        }
    }
}
