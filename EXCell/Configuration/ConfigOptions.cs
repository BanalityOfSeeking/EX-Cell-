namespace Game.ConfigurationStore
{
    public class ConfigOptions
    {
        public const string Config = "ClientConfig";
        public string informationProviderGLN { get; set; }
        public string informationProviderName { get; set; }
        public string manufacturerGLN { get; set; }
        public string manufacturerName { get; set; }
    }
}