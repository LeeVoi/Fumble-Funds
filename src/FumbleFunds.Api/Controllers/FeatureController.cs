using FumbleFunds.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FumbleFunds.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeatureController : ControllerBase
{
    private readonly IFeatureService _featureService;
    
    public FeatureController(IFeatureService featureService)
    {
        _featureService = featureService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetFeatureFlagAsync([FromQuery] string featureName)
    {
        // Assuming you have a service to check feature flags
        var isEnabled = await _featureService.GetFeatureFlagAsync(featureName);
        
        return isEnabled 
            ? Ok(isEnabled)
            : NotFound($"Feature '{featureName}' is not enabled.");
        
    }
}