using System;
using System.Collections.Generic;
using System.Text;

namespace DbScrambler.Core.Models
{  
    public class Profile
    {
        public Profile()
        {
            Scramblers = new Dictionary<string, IScrambler>();
            Tables = new List<Table>();
        }

        public string DatabaseType { get; set; }
        public string ConnectionString { get; set; }
        public string Seed { get; set; }
        public Dictionary<string, IScrambler> Scramblers { get; set; }

        public List<Table> Tables  { get; set; }

        public bool IsValid()
        {
            HashSet<string> dbs = new HashSet<string> {"postgresql"};

            if (dbs.Contains(DatabaseType)) return false;

            return true;
        }
    }
}
