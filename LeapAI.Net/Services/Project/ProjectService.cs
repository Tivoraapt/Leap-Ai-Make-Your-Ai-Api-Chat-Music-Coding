using LeapAI.Net.SDK.Interfaces;

namespace LeapAI.Net.SDK.Services.Image
{
    public class ProjectService : LeapService, IProjectService
    {
        public ProjectService(LeapAiOptions options, HttpClient? client = null) 
            : base(options, client)
        { }

        /// <summary>
        /// Deletes the project with the given ID
        /// </summary>
        /// <param name="projectId">The ID of the project to delete</param>
        /// <returns>An empty string if successful, the Http status code otherwise</returns>
        /// <exception cref="ArgumentException">Occurs if no project ID is provided</exception>
        /// <remarks>
        /// This will delete anything associated with 
        /// the project. This includes:
        /// - Tuned models
        /// - Image jobs
        /// - API Keys
        /// </remarks>
        public async Task<string> DeleteProjectAsync(string projectId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(projectId))
                throw new ArgumentException("No project ID was provided.");

            var response = await _httpClient.DeleteAsync(_endpointProvider.ProjectDelete(projectId),
                cancellationToken);

            if (response.IsSuccessStatusCode)
                return "";
            else
                return $"{response.StatusCode}";
        }
    }
}
