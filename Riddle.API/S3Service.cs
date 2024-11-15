using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon;

namespace Riddle.API
{
    public class s3Service
    {
        private readonly string accessKey = "";
        private readonly string secretKey = "q572qw2XdRLOTzh9Wt1CcDnv+aqWw1Bo7czlvTSt";
        private readonly string bucketName = "iquinsayas";
        private readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;

        public async Task<string> UploadFileToS3(IFormFile file)
        {
            var client = new AmazonS3Client(accessKey, secretKey, bucketRegion);
            var fileTransferUtility = new TransferUtility(client);

            var fileName = Path.GetFileName(file.FileName);
            var fileUrl = $"https://{bucketName}.s3.amazonaws.com/{fileName}";

            // Save the file to a temporary location before uploading
            var tempFilePath = Path.GetTempFileName();
            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            try
            {
                // Upload the file to AWS S3
                await fileTransferUtility.UploadAsync(tempFilePath, bucketName, fileName);
                return fileUrl;
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine($"Error uploading to S3: {e.Message}");
                return null;
            }
            finally
            {
                // Cleanup temp file
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
            }
        }
    }
}
