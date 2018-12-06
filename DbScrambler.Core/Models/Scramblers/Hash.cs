using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DbScrambler.Core.Models.Scramblers
{
    public class Hash : BaseScrambler
    {
        public Hash(string seed) : base(seed)
        {
           
        }

        public override object Scramble(object value)
        {
            String text = value.ToString();
            var valueBytes = KeyDerivation.Pbkdf2(
                                password: text,
                                salt: Encoding.UTF8.GetBytes(Salt),
                                prf: KeyDerivationPrf.HMACSHA512,
                                iterationCount: 10000,
                                numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }
    }
}

