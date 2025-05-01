namespace LeapAI.Net.SDK.ObjectModels
{
    public static class PreTrainedModels
    {
        public static Dictionary<string, string?> All => 
            typeof(PreTrainedModels).GetProperties().Where(p => p.PropertyType == typeof(string))
                .ToDictionary(p => p.Name, p => (string)p.GetValue(null));

        public static string StableDiffusion1_5 => "8b1b897c-d66d-45a6-b8d7-8e32421d02cf";
        public static string StableDiffusion2_1 => "ee88d150-4259-4b77-9d0f-090abe29f650";
        public static string OpenJourney4 => "1e7737d7-545e-469f-857f-e4b46eaa151d";
        public static string OpenJourney2 => "d66b1686-5e5d-43b2-a2e7-d295d679917c";
        public static string OpenJourney1 => "7575ea52-3d4f-400f-9ded-09f7b1b1a5b8";
        public static string ModernDisney => "8ead1e66-5722-4ff6-a13f-b5212f575321";
        public static string FutureDiffusion => "1285ded4-b11b-4993-a491-d87cdfe6310c";
        public static string RealisticVision2_0 => "eab32df0-de26-4b83-a908-a83f3015e971";
    }
}
