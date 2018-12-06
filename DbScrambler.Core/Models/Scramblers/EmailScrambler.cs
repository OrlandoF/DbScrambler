using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DbScrambler.Core.Models.Scramblers
{
    public class EmailScrambler : BaseScrambler
    {
        const string _invalidEmail = "invalid@example.com";
        Hash _hasher;

        public EmailScrambler(string salt) : base(salt)
        {
            _hasher = new Hash(salt);
        }
        public override object Scramble(object value)
        {
            if (value == null) return "";

            String email = value.ToString();

            if (String.IsNullOrWhiteSpace(email)) return "";

            var emailParts = email.Split('@');

            if (emailParts.Length != 2) return _invalidEmail;

            var hashed = _hasher.Scramble(emailParts[0]);

            var newEmail = hashed + "@" + emailParts[1];

            return newEmail;
        }

    }
}
