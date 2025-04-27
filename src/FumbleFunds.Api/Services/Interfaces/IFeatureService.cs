namespace FumbleFunds.Api.Services.Interfaces;
public interface IFeatureService
{
    Task<bool> GetFeatureFlagAsync(string featureName);
}