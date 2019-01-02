using GitLabApi.Filters;
using GitLabApi.Models;
using GitLabApi.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitLabApi
{
    public class GitLabApiClient
    {
        public string ServerUrl { get; set; } = "https://gitlab.com";
        public string PrivateToken { get; set; }

        public async Task<IEnumerable<Milestone>> ListProjectMilestonesAsync(string projectNamespace)
        {
            return await ListProjectMilestonesAsync(projectNamespace, null);
        }

        public async Task<IEnumerable<Milestone>> ListProjectMilestonesAsync(string projectNamespace, ListMilestonesFilters filters)
        {
            try
            {
                var qsb = CreateQueryStringBuilder();
                var url = CreateUrl("/projects/{0}/milestones", projectNamespace);

                filters?.AddToQueryString(qsb);

                return await GetAllPagesAsync<Milestone>(url, qsb);
            }
            catch (Exception ex)
            {
                throw new GitLabApiException("An error has occurred", ex);
            }
        }

        public async Task<Milestone> GetProjectMilestoneAsync(string projectNamespace, int milestoneId)
        {
            try
            {
                var qsb = CreateQueryStringBuilder();
                var url = CreateUrl("/projects/{0}/milestones/{1}", projectNamespace, milestoneId.ToString());

                return await GetJsonAsync<Milestone>(url, qsb);
            }
            catch (Exception ex)
            {
                throw new GitLabApiException("An error has occurred", ex);
            }
        }

        public async Task<IEnumerable<Milestone>> ListGroupMilestonesAsync(string groupNamespace)
        {
            return await ListGroupMilestonesAsync(groupNamespace, null);
        }

        public async Task<IEnumerable<Milestone>> ListGroupMilestonesAsync(string groupNamespace, ListMilestonesFilters filters)
        {
            try
            {
                var qsb = CreateQueryStringBuilder();
                var url = CreateUrl("/groups/{0}/milestones", groupNamespace);

                filters?.AddToQueryString(qsb);

                return await GetAllPagesAsync<Milestone>(url, qsb);
            }
            catch (Exception ex)
            {
                throw new GitLabApiException("An error has occurred", ex);
            }
        }

        public async Task<Milestone> GetGroupMilestoneAsync(string groupNamespace, int milestoneId)
        {
            try
            {
                var qsb = CreateQueryStringBuilder();
                var url = CreateUrl("/groups/{0}/milestones/{1}", groupNamespace, milestoneId.ToString());

                return await GetJsonAsync<Milestone>(url, qsb);
            }
            catch (Exception ex)
            {
                throw new GitLabApiException("An error has occurred", ex);
            }
        }

        public async Task<IEnumerable<Issue>> ListIssuesAsync()
        {
            return await ListIssuesAsync(null);
        }

        public async Task<IEnumerable<Issue>> ListIssuesAsync(ListIssuesFilters filters)
        {
            try
            {
                var qsb = CreateQueryStringBuilder();
                var url = CreateUrl("/issues");

                filters?.AddToQueryString(qsb);

                return await GetAllPagesAsync<Issue>(url, qsb);
            }
            catch (Exception ex)
            {
                throw new GitLabApiException("An error has occurred", ex);
            }
        }

        public async Task<IEnumerable<Issue>> ListProjectIssuesAsync(string projectNamespace)
        {
            return await ListProjectIssuesAsync(projectNamespace, null);
        }

        public async Task<IEnumerable<Issue>> ListProjectIssuesAsync(string projectNamespace, ListIssuesFilters filters)
        {
            try
            {
                var qsb = CreateQueryStringBuilder();
                var url = CreateUrl("/projects/{0}/issues", projectNamespace);

                filters?.AddToQueryString(qsb);

                return await GetAllPagesAsync<Issue>(url, qsb);
            }
            catch (Exception ex)
            {
                throw new GitLabApiException("An error has occurred", ex);
            }
        }

        public async Task<IEnumerable<Issue>> ListGroupIssuesAsync(string groupNamespace)
        {
            return await ListGroupIssuesAsync(groupNamespace, null);
        }

        public async Task<IEnumerable<Issue>> ListGroupIssuesAsync(string groupNamespace, ListIssuesFilters filters)
        {
            try
            {
                var qsb = CreateQueryStringBuilder();
                var url = CreateUrl("/groups/{0}/issues", groupNamespace);

                filters?.AddToQueryString(qsb);

                return await GetAllPagesAsync<Issue>(url, qsb);
            }
            catch (Exception ex)
            {
                throw new GitLabApiException("An error has occurred", ex);
            }
        }

        private async Task<IEnumerable<TElement>> GetAllPagesAsync<TElement>(string url, QueryStringBuilder qsb)
        {
            var result = new List<TElement>();
            var items = Enumerable.Empty<TElement>();
            var page = 1;
            var perPage = 100;

            qsb.SetValue("per_page", perPage.ToString());

            do
            {
                qsb.SetValue("page", (page++).ToString());

                items = await GetJsonAsync<IEnumerable<TElement>>(url, qsb);

                result.AddRange(items);

            } while (items.Count() == perPage);

            return result;
        }

        private async Task<TResult> GetJsonAsync<TResult>(string url, QueryStringBuilder qsb)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url + qsb.ToString());

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResult>(content);
        }

        private string CreateUrl(string path, params string[] pathParams)
        {
            var url = new StringBuilder();

            url.Append(ServerUrl);

            if (!ServerUrl.EndsWith("/"))
            {
                url.Append("/");
            }

            url.Append("api/v4");

            if (!path.StartsWith("/"))
            {
                url.Append("/");
            }

            var escapedPathParams = pathParams
                .Select(x => Uri.EscapeDataString(x))
                .ToArray();

            url.Append(string.Format(path, escapedPathParams));

            return url.ToString();
        }

        private QueryStringBuilder CreateQueryStringBuilder()
        {
            var qsb = new QueryStringBuilder();

            if (!string.IsNullOrEmpty(PrivateToken))
            {
                qsb.SetValue("private_token", PrivateToken);
            }

            return qsb;
        }
    }
}
