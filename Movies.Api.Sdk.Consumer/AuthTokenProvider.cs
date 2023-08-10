using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Api.Sdk.Consumer
{
    public class AuthTokenProvider
    {
        private readonly HttpClient _httpClient;
        private string _cachedtoken = string.Empty;
        private static readonly SemaphoreSlim Lock = new(1, 1);

        public AuthTokenProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetTokenAsync()
        {
            if(!string.IsNullOrEmpty(_cachedtoken))
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(_cachedtoken);
                var expireTimeText = jwt.Claims.Single(claim => claim.Type == "exp").Value;
                var expiryDateTime = UnixTimeStampToDateTime(int.Parse(expireTimeText));
                if(expiryDateTime > DateTime.UtcNow) 
                {
                    return _cachedtoken;
                }

            }

            await Lock.WaitAsync();
            var response = await _httpClient.PostAsJsonAsync("https://localhost:5003/token", new
            {
                userId = "d8566de3-b1a6-4a9b-b842-8e3887a82e42",
                email = "seucu@nickchapsas.com",
                customClaims = new Dictionary<string, object>
                {
                    {"admin", true },
                    {"trusted_member", true }
                }
            });
            var newToken = await response.Content.ReadAsStringAsync();
            _cachedtoken = newToken;
            Lock.Release();
            return newToken;


        }


        private static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

    }
}
