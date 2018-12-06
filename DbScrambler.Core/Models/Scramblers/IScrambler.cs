using System;
using System.Collections.Generic;
using System.Text;

namespace DbScrambler.Core.Models
{
    public interface IScrambler
    {
        Object Scramble(Object value);
        Dictionary<string, object> Properties { get; set; }
    }
}
