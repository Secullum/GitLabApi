using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GitLabApi.Models
{
    public class Issue
    {
        public enum IssueState
        {
            [JsonProperty("opened")]
            Opened,
            [JsonProperty("closed")]
            Closed,
            [JsonProperty("reopened")]
            Reopened
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

        [JsonProperty("state")]
        public IssueState State { get; set; }

        [JsonProperty("author")]
        public User Author { get; set; }

        [JsonProperty("milestone")]
        public Milestone Milestone { get; set; }

        [JsonProperty("assignees")]
        public IEnumerable<User> Assignees { get; set; }

        [JsonProperty("labels")]
        public IEnumerable<string> Labels { get; set; }

        [JsonProperty("due_date")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("user_notes_count")]
        public int UserNotesCount { get; set; }

        [JsonProperty("weight")]
        public int? Weight { get; set; }

        [JsonProperty("confidential")]
        public bool Confidential { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("web_url")]
        public string WebUrl { get; set; }
    }
}
