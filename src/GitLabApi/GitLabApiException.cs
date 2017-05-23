using System;

namespace GitLabApi
{
    public class GitLabApiException : Exception
    {
        public GitLabApiException(string message) : this(message, null)
        { }

        public GitLabApiException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
