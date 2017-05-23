using Newtonsoft.Json;
using System;

namespace GitLabApi.Models
{
    public class Milestone
    {
        public enum MilestoneState
        {
            [JsonProperty("active")]
            Active,
            [JsonProperty("closed")]
            Closed
        }

        [JsonProperty("id")]
        public int GlobalId { get; set; }

        [JsonProperty("iid")]
        public int LocalId { get; set; }

        [JsonProperty("project_id")]
        public int ProjectId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("due_date")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("state")]
        public MilestoneState State { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
