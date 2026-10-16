using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace AllTrailsAdmin.Services
{
    public class AzureStorageService : IAzureStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly BlobServiceClient _blobServiceClient;
        private string containerName;

        // Constructor
        public AzureStorageService(IConfiguration configuration)
        {
            _configuration = configuration;

            containerName = _configuration["AzureStorage:ContainerName"] ?? throw new InvalidOperationException("Missing configuration: AzureStorage:ContainerName");

            string connectionString = _configuration["AzureStorage:ConnectionString"] ?? throw new InvalidOperationException("Missing configuration: AzureStorage:ConnectionString");

            _blobServiceClient = new BlobServiceClient(connectionString);
        }


        // Return the image file URL
        public async Task<string> UploadFileAsync(IFormFile file, string filename)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(filename);

            var options = new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders
                {
                    ContentType = file.ContentType
                }
            };

            // file I/O
            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, options);
            }

            return blobClient.Uri.ToString(); // the URL of the new file
        }

    }
}
}
