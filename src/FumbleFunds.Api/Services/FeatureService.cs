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
            var config = new EdgeFeatureHubConfig("http://localhost:8085/api", "da41fb5a-5951-4dc2-b6c8-5ee5da422160/cupIghrMbgeMJs7ZehsOzK7v48B6kX7fO7maYqJb");

            var fh = await config.NewContext().Build();
            var flag = fh[featureName].IsEnabled;

            return flag;
        }
    }
}

