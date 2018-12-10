using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DbScrambler.Core.Models.Scramblers
{
    public abstract class BaseScrambler : Models.BaseScrambler
    {
        public BaseScrambler(string salt)
        {
            Salt = salt;
            Properties = new Dictionary<string, string>();
            Errors = new List<string>();
        }

        public Dictionary<string, string> Properties { get;  }
        protected string Salt { get; set; }

        public List<string> Errors { get; }

        public abstract object Scramble(object value, Dictionary<string, string> fields);
        public abstract bool IsValid();

        protected string GetOutput(string pattern, string value, Dictionary<string, string> fields, Dictionary<string, string> outputs)
        {
            string response=pattern;
            string fieldValue;
            string fieldName;

            if (String.IsNullOrWhiteSpace(pattern)) return value;
            Regex rx = new Regex("{field:(\\w+)}");
            foreach (var match in rx.Matches(response))
            {
                fieldName = match.ToString();
                fieldValue = Properties[match.ToString()];
                response = response.Replace(fieldName, fieldValue);
            }
            rx = new Regex("{out:(\\w+)}");
            foreach (Match match in rx.Matches(response))
            {
                fieldName = match.ToString();
                fieldValue = outputs[match.Groups[1].Value];
                response = response.Replace(fieldName, fieldValue);
            }
            return response;
        }

    }
}
