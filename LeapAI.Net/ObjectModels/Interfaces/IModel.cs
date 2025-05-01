namespace LeapAI.Net.SDK.ObjectModels.Interfaces
{
    public  interface IModel
    {


        /// <summary>
        /// The ID of the model creation job
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// The name of the model
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The subject keyword used during inference to trigger 
        /// specific styles
        /// </summary>
        public string? SubjectKeyword { get; set; }

        /// <summary>
        /// A random string that will replace the subject keyword 
        /// at the time of inference. If not provided, a random 
        /// string will be automatically generated.
        /// </summary>
        public string? SubjectIdentifier { get; set; }
    }
}
