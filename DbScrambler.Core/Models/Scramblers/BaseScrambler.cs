using System;
using System.Collections.Generic;
using System.Text;

namespace DbScrambler.Core.Models.Scramblers
{
    public class BaseScrambler : IScrambler
    {

        public BaseScrambler(string salt)
        {
            Salt = salt;
            Properties = new Dictionary<string, object>();
        }

        public Dictionary<string, object> Properties { get;  }
      
        public virtual object Scramble(object value)
        {
            throw new NotImplementedException();
        }

        protected string Salt { get; set; }

    }
}
