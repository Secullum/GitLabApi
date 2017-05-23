using Microsoft.Extensions.Configuration;

namespace GitLabApi.Test
{
    public class GitLabApiClientTest
    {
        private GitLabApiClient BuildGitLabApiClient()
        {
            var client = new GitLabApiClient();

            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<GitLabApiClientTest>()
                .Build();

            var serverUrl = configuration["ServerUrl"];
            var privateToken = configuration["PrivateToken"];

            if (!string.IsNullOrEmpty(serverUrl))
            {
                client.ServerUrl = serverUrl;
            }

            if (!string.IsNullOrEmpty(privateToken))
            {
                client.PrivateToken = privateToken;
            }

            return client;
        }
    }
}
