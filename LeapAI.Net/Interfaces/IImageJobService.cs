using LeapAI.Net.SDK.ObjectModels.RequestModels;
using LeapAI.Net.SDK.ObjectModels.ResponseModels;

namespace LeapAI.Net.SDK.Interfaces
{
    internal interface IImageJobService
    {
        Task<ImageJobCreateResponse> CreateImageJobAsync(ImageJobCreateRequest request,
            string? modelId = null, CancellationToken cancellationToken = default);

        Task<ImageJobCreateResponse[]> GetImageJobsAsync(string modelId,  
            CancellationToken cancellationToken = default);

        Task<ImageJobResponse> GetImageJobAsync(string modelId, string jobInferenceId, 
            CancellationToken cancellationToken = default);

        Task<string> DeleteImageJobAsync(string modelId, string jobInferenceId, 
            CancellationToken cancellationToken = default);
    }
}
