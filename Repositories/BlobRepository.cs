using AI_Updater.Enums;
using AI_Updater.Repositories.Contracts;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;

namespace AI_Updater.Repositories
{
    public class BlobRepository : IBlobRepository
    {
        private readonly BlobServiceClient _blobClient;
        private readonly BlobOptions _blobOptions;
        private readonly ILogger<BlobRepository> _logger;
        public BlobRepository(string blobConnectionString, IOptions<BlobOptions> options, ILogger<BlobRepository> logger)
        {
            _blobClient = new BlobServiceClient(blobConnectionString);
            _blobOptions = options.Value;
            _logger = logger;
        }

        public async Task<string> UploadFileAsync(Stream stream, string fileName)
        {
            try
            {
                BlobClient blob = ResolveContainerClient(Constants.UploadContainer).GetBlobClient(fileName);
                BlobContentInfo response = await blob.UploadAsync(stream);
                if (response != null)
                {
                    return blob.Name;
                }
            }
            catch (RequestFailedException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return string.Empty;
        }

        public async Task<byte[]> DownloadFileToStreamAsync(string fileName)
        {
            byte[] content = [];
            try
            {
                BlobClient blobClient = ResolveContainerClient(Constants.DownloadContainer).GetBlobClient(fileName);
                BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();
                content = downloadResult.Content.ToArray();
                return content;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return content;
        }

        private BlobContainerClient ResolveContainerClient(string containerName)
        {
            ArgumentNullException.ThrowIfNull(containerName);

            switch (containerName)
            {
                case Constants.UploadContainer: return InitializeContainer(Constants.UploadContainer);
                case Constants.DownloadContainer: return InitializeContainer(Constants.DownloadContainer);
                default:
                    break;
            }
            return InitializeContainer(Constants.DefaultContainer);
        }

        private BlobContainerClient InitializeContainer(string containerName)
        {
            BlobContainerClient containerClient = _blobClient.GetBlobContainerClient(containerName);
            containerClient.CreateIfNotExists();
            return containerClient;
        }
    }
}
