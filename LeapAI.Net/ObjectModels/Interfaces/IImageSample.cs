namespace LeapAI.Net.SDK.ObjectModels.Interfaces
{
    public interface IImageSample
    {

        /// <summary>
        /// The ID of the sample
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// When the sample was created
        /// </summary>
        public string? CreatedAt { get; set; }

        /// <summary>
        /// The URI of the image sample
        /// </summary>
        public string? Uri { get; set; }
    }
}
