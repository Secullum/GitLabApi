using System;
using System.Collections.Generic;
using System.Linq;

namespace GitLabApi.Utils
{
    public class QueryStringBuilder
    {
        private Dictionary<string, string> values = new Dictionary<string, string>();

        public void SetValue(string key, string value)
        {
            values[key] = value;
        }

        public void RemoveValue(string key)
        {
            values.Remove(key);
        }

        public override string ToString()
        {
            if (values.Count == 0)
            {
                return "";
            }

            var qs = values
                .Select(x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value)}")
                .Aggregate((acc, x) => acc + "&" + x);

            if (!string.IsNullOrEmpty(qs))
            {
                qs = "?" + qs;
            }

            return qs;
        }
    }
}
