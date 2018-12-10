using System;
using System.Collections.Generic;
using System.Text;
using DbScrambler.Core.Models.Scramblers;
using Xunit;

namespace DbScrambler.Core.Test.Scramblers
{
    public class HashTest
    {
        [Fact]
        public void ValidHash()
        {
            const string value = "Test";
            const string salt = "TestSalt";
            const string expected = "RqaOK2KlhH7p6fXkuwaMJFedviPc3VePnAUdl4fiuZg=";

            var hash = new Hash(salt);

            var response = hash.Scramble(value,null).ToString();

            Assert.Equal(expected, response);
        }
    }
}
