namespace LeapAI.Net.SDK.Interfaces
{
    internal interface ILeapAiEndpointProvider
    {
        string ImageJobCreate(string modelId);
        string ImageJobsGet(string modelId);
        string ImageJobGet(string modelId, string jobInferenceId);
        string ImageJobDelete(string modelId, string jobInferenceId);
        string ProjectDelete(string projectId);
        string RemixJobUsingFileCreate(string modelId);
        string RemixJobUsingUrlCreate(string modelId);
        string RemixJobGet(string modelId, string remixId);
        string ModelCreate();
        string ModelListGet();
        string QueueTrainingJob(string modelId);
        string ModelGet(string modelId);
        string ModelDelete(string modelId);
        string ImageSampleUpload(string modelId);
        string ImageSampleListGet(string modelId);
        string ImageSampleViaUrlUpload(string modelId);
        string ImageSampleGet(string modelId, string sampleId);
        string ImageSampleArchive(string modelId, string sampleId);
        string ModelVersionListGet(string modelId);
        string ModelVersionGet(string modelId, string versionId);
    }
}
