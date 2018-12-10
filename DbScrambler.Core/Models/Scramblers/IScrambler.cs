using System;
using System.Collections.Generic;
using System.Text;

namespace DbScrambler.Core.Models
{
    public interface BaseScrambler
    {
        Object Scramble(Object value, Dictionary<string, string> fields);
        Dictionary<string, string> Properties { get;}
        List<string> Errors { get; }
        bool IsValid();
    }
}
