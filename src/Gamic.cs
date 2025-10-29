using System.Net.Http;
using System.Net.Http.Headers;

namespace GamicApi
{
    public class Gamic
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://api.gamic.app/api";
        public Gamic()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("gamic-guild-mobile");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> SendVerificationCode(string email)
        {
            var response = await httpClient.PostAsync($"{apiUrl}/login/email/sendVerificationCode?email={email}", null);
            return await response.Content.ReadAsStringAsync();
        }
      
        public async Task<string> VerifyEmail(string email, int verificationCode)
        {
            var response = await httpClient.PostAsync(
                $"{apiUrl}/login/email/verificationCode?email={email}&code={verificationCode}", null);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Login(string email, string password)
        {
            var response = await httpClient.PostAsync(
                $"{apiUrl}/login/email?email={email}&password={password}", null);
            httpClient.DefaultRequestHeaders.Add("cookie", response.Headers.GetValues("Set-Cookie").FirstOrDefault());
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAccountInfo()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/user/current");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetChains()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/v3/tokens/chains");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetTokenNetwork()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/token/network/all");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetGames()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/games");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPrivateRooms()
        {
            var response = await httpClient.GetAsync($"{apiUrl}/room/my/privateRooms");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
