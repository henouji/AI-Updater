namespace AI_Updater.Enums
{
    public class BlobOptions
    {
        public const string BlobConfiguration = nameof(BlobConfiguration);
        public string UploadContainer { get; set; } = String.Empty;
        public string DownloadContainer { get; set; } = String.Empty;


    }
}
