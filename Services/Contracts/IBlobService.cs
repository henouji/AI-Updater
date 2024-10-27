namespace AI_Updater.Services.Contracts
{
    public interface IBlobService
    {
        Task<string> UploadFileAsync(Stream stream, string fileName);
    }
}
