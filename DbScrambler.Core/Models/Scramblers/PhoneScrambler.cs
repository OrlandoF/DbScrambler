using System;
using System.Collections.Generic;
using System.Text;

namespace DbScrambler.Core.Models.Scramblers
{
    public class PhoneScrambler : BaseScrambler
    {
        public PhoneScrambler(string salt) : base(salt)
        {
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        public override object Scramble(object value, Dictionary<string, string> fields)
        {
            throw new NotImplementedException();
        }
    }
}
