# GitLabApi

.NET GitLab API client

## Example

```cs
var client = new GitLabApiClient();

client.PrivateToken = "myprivatetoken";

var issues = await client.ListProjectIssuesAsync("group/proj");

// Do something with issues...
```
