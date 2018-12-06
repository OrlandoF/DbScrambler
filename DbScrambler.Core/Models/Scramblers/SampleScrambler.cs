using System;
using System.Collections.Generic;
using System.Text;

namespace DbScrambler.Core.Models.Scramblers
{
    public class SampleScrambler : IScrambler
    {
        public SampleScrambler()
        {
            Properties = new Dictionary<string, object>();
        }
        public Dictionary<string, object> Properties { get; set; }

        public object Scramble(object value)
        {
            throw new NotImplementedException();

        }
    }
}
