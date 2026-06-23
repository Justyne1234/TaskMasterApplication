using Google.Apis.Auth;
using Microsoft.Extensions.Options;
using TaskMaster.Models.Options;

namespace TaskMaster.Services;
public class GoogleApiService
{
    private readonly GoogleAuthOptions _options;
    public GoogleApiService(IOptions<GoogleAuthOptions> options)
    {
        _options = options.Value;
    }
    public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string idToken)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new[] { _options.ClientId }
        };

        return await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
    }
}

