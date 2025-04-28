using FeatureHubSDK;
using FumbleFunds.Api.Services.Interfaces;

namespace FumbleFunds.Api.Services
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> GetFeatureFlagAsync(string featureName)
        {
            var config = new EdgeFeatureHubConfig("http://featurehub:8085", "9900a26b-a530-4484-8309-86d71c48d755/xbGNRtQSqIro3LPKrUQKHRtshlfrbBUNnRRV8BkH");

            try
            {
                var fh = await config.NewContext().Build();
                if(!fh[featureName].Exists)
                {
                    Console.WriteLine($"Feature flag {featureName} does not exist.");
                    return false;
                }
                var flag = fh[featureName].IsEnabled;
                return flag;


            }
            catch (Exception e)
            {
                Console.WriteLine("Error while fetching feature flag: " + e.Message);
                return false;
            }
        }
    }
}

