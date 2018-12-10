using System;
using System.Collections.Generic;
using System.Text;
using DbScrambler.Core.Models.Scramblers;
using Xunit;

namespace DbScrambler.Core.Test.Scramblers
{
    public class EmailScramblerTest
    {
        [Fact]
        public void ValidEmail()
        {
            const string value = "Test@example.com";
            const string salt = "TestSalt";
            const string expected = "RqaOK2KlhH7p6fXkuwaMJFedviPc3VePnAUdl4fiuZg=@example.com";

            var emailScrambler = new EmailScrambler(salt);

            var response = emailScrambler.Scramble(value,null).ToString();

            Assert.Equal(expected, response);
        }
        [Fact]
        public void invalidEmail()
        {
            const string value = "Test@@example.com";
            const string value2 = "Testexample.com";
            const string salt = "TestSalt";
            const string expected = "invalid@example.com";

            var emailScrambler = new EmailScrambler(salt);

            var response = emailScrambler.Scramble(value,null).ToString();
            Assert.Equal(expected, response);

            response = emailScrambler.Scramble(value2,null).ToString();
            Assert.Equal(expected, response);

        }
        [Fact]
        public void EmptyEmail()
        {
            const string value = "   ";
            const string salt = "TestSalt";
            const string expected = "";

            var emailScrambler = new EmailScrambler(salt);

            var response = emailScrambler.Scramble(value,null).ToString();

            Assert.Equal(expected, response);
        }
        [Fact]
        public void NullEmail()
        {
            const string value = null;
            const string salt = "TestSalt";
            const string expected = "";

            var emailScrambler = new EmailScrambler(salt);

            var response = emailScrambler.Scramble(value,null).ToString();

            Assert.Equal(expected, response);
        }

    }
}
