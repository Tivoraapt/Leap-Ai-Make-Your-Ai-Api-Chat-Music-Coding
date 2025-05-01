using LeapAI.Net.SDK.Interfaces;

namespace LeapAI.Net.SDK.EndpointProviders
{
    internal class LeapAiEndpointProvider : ILeapAiEndpointProvider
    {
        private readonly string _apiVersion;

        /// <summary>
        /// Constructor for the endpoint provider
        /// </summary>
        /// <param name="apiVersion">The version of the API to use</param>
        /// <example>
        /// Here is an example of how to use the endpoint provider:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// </code>
        /// </example>
        public LeapAiEndpointProvider(string apiVersion)
        {
            _apiVersion = apiVersion;
        }

        /// <summary>
        /// Returns the endpoint for creating an image job
        /// </summary>
        /// <param name="modelId">The model's ID</param>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ImageJobCreate(PreTrainedModels.OpenJourney4);
        /// </code>
        /// </example>
        public string ImageJobCreate(string modelId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/inferences";
        }

        /// <summary>
        /// Returns the endpoint for getting all image jobs for a model
        /// </summary>
        /// <param name="modelId">The model's ID</param>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ImageJobsGet(PreTrainedModels.OpenJourney4);
        /// </code>
        /// </example>
        public string ImageJobsGet(string modelId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/inferences";
        }

        /// <summary>
        /// Returns the endpoint for getting a specific image job
        /// </summary>
        /// <param name="modelId">The model's ID</param>
        /// <param name="jobInferenceId">The image job's inference ID</param>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ImageJobGet(PreTrainedModels.OpenJourney4, 
        /// "1234");
        /// </code>
        /// </example>
        public string ImageJobGet(string modelId, string jobInferenceId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/inferences/" +
                   $"{jobInferenceId}";
        }

        /// <summary>
        /// Returns the endpoint for deleting a specific image job
        /// </summary>
        /// <param name="modelId">The model's ID</param>
        /// <param name="jobInferenceId">The image job's inference ID</param>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ImageJobDelete(PreTrainedModels.OpenJourney4,
        /// "1234");
        /// </code>
        /// </example>
        public string ImageJobDelete(string modelId, string jobInferenceId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/inferences/" +
                   $"{jobInferenceId}";
        }

        /// <summary>
        /// Returns the endpoint for deleting a project
        /// </summary>
        /// <param name="projectId">The project ID</param>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ProjectDelete("1234");
        /// </code>
        /// </example>
        /// <remarks>
        /// This will delete anything associated with 
        /// the project. This includes:
        /// - Tuned models
        /// - Image jobs
        /// - API Keys
        /// </remarks>
        public string ProjectDelete(string projectId)
        {
            return $"/api/{_apiVersion}/projects/{projectId}";
        }

        /// <summary>
        /// Returns the endpoint for creating an image remix job using a file
        /// </summary>
        /// <param name="modelId">The model's ID</param>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.RemixJobUsingFileCreate(PreTrainedModels.OpenJourney4);
        /// </code>
        /// </example>
        public string RemixJobUsingFileCreate(string modelId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/remix";
        }

        /// <summary>
        /// Returns the endpoint for creating an image remix job using a URL
        /// </summary>
        /// <param name="modelId">The model's ID</param>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.RemixJobUsingUrlCreate(PreTrainedModels.OpenJourney4);
        /// </code>
        /// </example>
        public string RemixJobUsingUrlCreate(string modelId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/remix/url";
        }

        /// <summary>
        /// Returns the endpoint for retrieving an image remix job
        /// </summary>
        /// <param name="modelId">The model's ID</param>
        /// <param name="remixId">The remix ID</param>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.RemixJobGet(PreTrainedModels.OpenJourney4,
        /// "1234");
        /// </code>
        /// </example>
        public string RemixJobGet(string modelId, string remixId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/remix/{remixId}";
        }

        /// <summary>
        /// Returns the endpoint for creating a model
        /// </summary>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ModelCreate();
        /// </code>
        /// </example>

        public string ModelCreate()
        {
            return $"/api/{_apiVersion}/images/models";
        }

        /// <summary>
        /// Returns the endpoint for getting the model list
        /// </summary>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ModelListGet();
        /// </code>
        /// </example>
        public string ModelListGet()
        {
            return $"/api/{_apiVersion}/images/models";
        }

        /// <summary>
        /// Returns the endpoint for queueing a training job
        /// </summary>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.QueueTrainingJob("Your model ID");
        /// </code>
        /// </example>
        /// <remarks>
        /// After uploading image samples via the samples endpoint. 
        /// You can use this endpoint to queue a new model version 
        /// to be trained. Upon completion, you'll be able to query 
        /// your custom model via the inference endpoint.
        /// </remarks>
        public string QueueTrainingJob(string modelId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/queue";
        }

        /// <summary>
        /// Returns the endpoint for retrieving a single model
        /// </summary>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ModelGet("Your model ID");
        /// </code>
        /// </example>
        public string ModelGet(string modelId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}";
        }

        /// <summary>
        /// Returns the endpoint for deleting a single model
        /// </summary>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ModelDelete("Your model ID");
        /// </code>
        /// </example>
        public string ModelDelete(string modelId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}";
        }

        /// <summary>
        /// Returns the endpoint for uploading model image samples
        /// </summary>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ImageSampleUpload("Your model ID");
        /// </code>
        /// </example>
        public string ImageSampleUpload(string modelId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/samples";
        }

        /// <summary>
        /// Returns the endpoint for getting model image samples
        /// </summary>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ImageSampleListGet("Your model ID");
        /// </code>
        /// </example>
        public string ImageSampleListGet(string modelId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/samples";
        }

        /// <summary>
        /// Returns the endpoint for uploading model image samples via URL
        /// </summary>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ImageSampleViaUrlUpload("Your model ID");
        /// </code>
        /// </example>
        public string ImageSampleViaUrlUpload(string modelId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/samples/url";
        }

        /// <summary>
        /// Returns the endpoint for retrieving a model image sample
        /// </summary>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ImageSampleGet("Your model ID", "1234");
        /// </code>
        /// </example>
        public string ImageSampleGet(string modelId, string sampleId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/samples/{sampleId}";
        }

        /// <summary>
        /// Returns the endpoint for archiving a model image sample
        /// </summary>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ImageSampleArchive("Your model ID", "1234");
        /// </code>
        /// </example>
        public string ImageSampleArchive(string modelId, string sampleId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/samples/{sampleId}/archive";
        }

        /// <summary>
        /// Returns the endpoint for listing all versions for a given model
        /// </summary>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ModelVersionListGet("Your model ID");
        /// </code>
        /// </example>
        public string ModelVersionListGet(string modelId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/versions";
        }

        /// <summary>
        /// Returns the endpoint for retrieving a given model version
        /// </summary>
        /// <returns>The endpoint string</returns>
        /// <example>
        /// Here is an example of how to use this method:
        /// <code>
        /// var ep = new LeapAiEndpointProvider("v1");
        /// var endpoint = ep.ModelVersionGet("Your model ID", "v1");
        /// </code>
        /// </example>
        public string ModelVersionGet(string modelId, string versionId)
        {
            return $"/api/{_apiVersion}/images/models/{modelId}/versions/{versionId}";
        }
    }    
}
