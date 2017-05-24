using GitLabApi.Utils;
using static GitLabApi.Models.Milestone;

namespace GitLabApi.Filters
{
    public class ListMilestonesFilters
    {
        public MilestoneState? State { get; set; }

        public void AddToQueryString(QueryStringBuilder qsb)
        {
            if (State.HasValue)
            {
                qsb.SetValue("state", State.Value == MilestoneState.Active ? "active" : "closed");
            }
        }
    }
}
