using LeapAI.Net.SDK.ObjectModels.RequestModels;
using LeapAI.Net.SDK.ObjectModels.ResponseModels;

namespace LeapAI.Net.SDK.Interfaces
{
    internal interface IRemixJobService
    {
        Task<RemixJobCreateResponse> CreateRemixJobFromFileAsync(RemixJobCreateRequest request, 
            string pathToFile, string? modelId = null, CancellationToken cancellationToken = default);

        Task<RemixJobCreateResponse> CreateRemixJobFromUrlAsync(RemixJobCreateRequest request,
            string? modelId = null, CancellationToken cancellationToken = default);

        Task<RemixJobResponse> GetRemixJobAsync(string modelId, string remixId,
            CancellationToken cancellationToken = default);
    }
}
