using Google.Apis.Auth;

namespace TaskMaster.Services;
public class GoogleApiService
{
    public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string idToken)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new[] { "441410491160-43v674dfj4912toma3ci3qtk2cvrsg8i.apps.googleusercontent.com" }
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

        return payload;
    }
}

