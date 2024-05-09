using Kooi.Application.Abstractions.Authentication;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Kooi.Domain.Common.Errors;
using ErrorOr;
using Kooi.Application.Users.Authentication.Commands;

namespace Infrastructure.Authentication
{
    internal sealed class JwtProvider : IJwtProvider
    {

        private readonly HttpClient _httpClient;

        public JwtProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ErrorOr<AuthenticationResult>> GetCredentialsAsync(string email, string password)
        {
            var request = new
            {
                email,
                password,
                returnSecureToken = true
            };

            var response = await _httpClient.PostAsJsonAsync("", request);
            if (response.IsSuccessStatusCode)
            {
                var authToken = await response.Content.ReadFromJsonAsync<AuthToken>();
                return new AuthenticationResult(authToken.IdToken);
            }
            else
            {
                return Errors.Authentication.LoginFailed;
            }
               
        }


        public class AuthToken
        {
            [JsonPropertyName("kind")]
            public string Kind { get; set; }

            [JsonPropertyName("localId")]
            public string LocalId { get; set; }

            [JsonPropertyName("email")]
            public string Email { get; set; }

            [JsonPropertyName("displayName")]
            public string DisplayName { get; set; }

            [JsonPropertyName("idToken")]
            public string IdToken { get; set; }

            [JsonPropertyName("registered")]
            public bool Registered { get; set; }

            [JsonPropertyName("refreshToken")]
            public string RefreshToken { get; set; }

            [JsonPropertyName("expiresIn")]
            public string ExpiresIn { get; set; }
        }
    }
}
