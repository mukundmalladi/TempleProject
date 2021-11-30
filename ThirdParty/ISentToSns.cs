using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace TempleProject.ThirdParty
{
    public interface ISentToSns
    {
        public Task<string> SendToSnsAsync(string phone, string message);
    }

    public class SentToSns : ISentToSns
    {
        private ILogger<SentToSns> logger;

        public SentToSns(ILogger<SentToSns> logger)
        {
            this.logger = logger;
        }

        public async Task<string> SendToSnsAsync(string phone, string message)
        {
            var client = new AmazonSimpleNotificationServiceClient(region: Amazon.RegionEndpoint.USEast1);

            var request = new PublishRequest
            {
                Message = $"Thank you for registering for {message} seva!",
                PhoneNumber = phone
            };

            try
            {
                var response = await client.PublishAsync(request);
                var result = response.MessageId;
                return result;             
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);                
                throw;
            }
        }
    }
}
