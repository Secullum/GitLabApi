using GitLabApi.Utils;
using Xunit;

namespace GitLabApi.Test.Utils
{
    public class QueryStringBuilderTest
    {
        [Fact]
        public void GivenNoValue_ReturnEmptyStrng()
        {
            var qsb = new QueryStringBuilder();

            Assert.Empty(qsb.ToString());
        }

        [Fact]
        public void GivenSingleValue_BuildTheQueryString()
        {
            var qsb = new QueryStringBuilder();

            qsb.SetValue("name", "thename");

            Assert.Equal("?name=thename", qsb.ToString());
        }

        [Fact]
        public void GivenMultipleValues_BuildTheQueryString()
        {
            var qsb = new QueryStringBuilder();

            qsb.SetValue("name", "thename");
            qsb.SetValue("page", "1");
            qsb.SetValue("path", "the/path");

            Assert.Equal("?name=thename&page=1&path=the%2Fpath", qsb.ToString());
        }

        [Fact]
        public void GivenExistentKey_UpdateItsValue()
        {
            var qsb = new QueryStringBuilder();

            qsb.SetValue("name", "thename");
            qsb.SetValue("name", "thename2");

            Assert.Equal("?name=thename2", qsb.ToString());
        }

        [Fact]
        public void RemoveValue_RemoveItFromQueryString()
        {
            var qsb = new QueryStringBuilder();

            qsb.SetValue("name", "thename");
            qsb.SetValue("page", "1");
            qsb.SetValue("path", "the/path");

            qsb.RemoveValue("page");

            Assert.Equal("?name=thename&path=the%2Fpath", qsb.ToString());
        }

        [Fact]
        public void RemoveLastValue_ReturnEmptyString()
        {
            var qsb = new QueryStringBuilder();

            qsb.SetValue("page", "1");

            qsb.RemoveValue("page");

            Assert.Empty(qsb.ToString());
        }
    }
}
