namespace AI_Updater.Repositories.Contracts
{
    public interface IBlobRepository
    {
        Task<string> UploadFileAsync(Stream stream, string fileName);
        Task<byte[]> DownloadFileToStreamAsync(string fileName);
    }
}
