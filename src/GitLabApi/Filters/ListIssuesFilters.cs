using GitLabApi.Utils;
using System.Collections.Generic;
using System.Linq;
using static GitLabApi.Models.Issue;

namespace GitLabApi.Filters
{
    public class ListIssuesFilters
    {
        public IssueState? State { get; set; }
        public IEnumerable<string> Labels { get; set; }
        public string Milestone { get; set; }

        public void AddToQueryString(QueryStringBuilder qsb)
        {
            if (State.HasValue)
            {
                qsb.SetValue("state", State.Value == IssueState.Opened ? "opened" : "closed");
            }

            if (Labels != null && Labels.Any())
            {
                qsb.SetValue("labels", Labels.Aggregate((acc, x) => acc + "," + x));
            }

            if (!string.IsNullOrEmpty(Milestone))
            {
                qsb.SetValue("milestone", Milestone);
            }
        }
    }
}
