using AI_Updater.Repositories.Contracts;
using AI_Updater.Services.Contracts;
using AI_Updater.Enums;
using AI_Updater.Utility;

namespace AI_Updater.Services
{
    public class BlobService : IBlobService
    {
        private readonly IBlobRepository _blobRepository;
        private readonly ILogger<BlobService> _logger;
        private IConfiguration _configuration;
        private readonly BlobOptions _blobOptions;
        public BlobService(IBlobRepository blobRepository, ILogger<BlobService> logger, IConfiguration configuration)
        {
            _blobRepository = blobRepository;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<string> UploadFileAsync(Stream stream, string fileName)
        {
            string blobName = await _blobRepository.UploadFileAsync(stream, fileName.AddTimeStamp());
            return blobName;
        }

        
    }
}
