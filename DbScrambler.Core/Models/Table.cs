using System;
using System.Collections.Generic;
using System.Text;

namespace DbScrambler.Core.Models
{
    public class Table
    {
        public Table()
        {
            Fields = new List<Field>();
        }
        public string Name { get; set; }
        public List<Field> Fields { get; set; }

    }
}
