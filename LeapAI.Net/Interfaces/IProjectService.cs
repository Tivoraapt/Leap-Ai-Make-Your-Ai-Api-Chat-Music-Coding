namespace LeapAI.Net.SDK.Interfaces
{
    internal interface IProjectService
    {
        Task<string> DeleteProjectAsync(string projectId, 
            CancellationToken cancellationToken = default);
    }
}
