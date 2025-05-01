using LeapAI.Net.SDK.ObjectModels.RequestModels;
using LeapAI.Net.SDK.ObjectModels.ResponseModels;

namespace LeapAI.Net.SDK.Interfaces
{
    internal interface IModelFineTuningService
    {
        Task<ModelCreateResponse> CreateModelAsync(ModelCreateRequest request,
            CancellationToken cancellationToken = default);

        Task<ModelResponse[]> ListModelsAsync(CancellationToken 
            cancellationToken = default);

        Task<ModelObjectResponse> ListModelsGetObjectAsync(CancellationToken
            cancellationToken = default);

        Task<ModelQueueTrainingResponse> QueueModelTrainingJobAsync(string modelId, 
            ModelQueueTrainingRequest request, 
            CancellationToken cancellationToken = default);

        Task<ModelResponse> RetrieveModelAsync(string modelId,  
            CancellationToken cancellationToken = default);

        Task<string> DeleteModelAsync(string modelId,
            CancellationToken cancellationToken = default);

        Task<ImageSampleCreateResponse[]> UploadImageSampleFromFileAsync(string modelId,
            string pathToFile,  CancellationToken cancellationToken = default);

        Task<ImageSampleCreateResponse[]> UploadImageSampleFromUrlAsync(string modelId,
            ImageSampleCreateRequest request, CancellationToken cancellationToken = default);

        Task<ImageSampleResponse[]> ListImageSamplesAsync(string modelId,
            CancellationToken cancellationToken = default);

        Task<ImageSampleResponse> GetImageSampleAsync(string modelId,
            string sampleId, CancellationToken cancellationToken = default);

        Task<ImageSampleArchiveResponse> ArchiveImageSampleAsync(string modelId,
            string sampleId, CancellationToken cancellationToken = default);

        Task<ModelVersionResponse[]> ListModelVersionsAsync(string modelId,
            CancellationToken cancellationToken = default);

        Task<ModelVersionResponse> GetModelVersionAsync(string modelId,
            string versionId, CancellationToken cancellationToken = default);
    }
}
