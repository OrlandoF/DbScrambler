using System;
using System.Collections.Generic;
using System.Text;
using DbScrambler.Core.Models.Scramblers;
using Xunit;

namespace DbScrambler.Core.Test.Scramblers
{
    public class AddressScramblerTest
    {
        [Fact]
        public void LoadingValidation()
        {
            const string salt = "TestSalt";
            AddressScrambler scrambler;

            scrambler = new AddressScrambler(salt);
            Assert.False(scrambler.IsValid());
            //Assert.Contains("Unable to load address csv file", scrambler.Errors);
            Assert.Contains("Missing pattern property", scrambler.Errors);
            Assert.Contains("Missing seed property", scrambler.Errors);
        }

        [Fact]
        public void ReturnZipCodeAndCity()
        {
            const string salt = "TestSalt";
            const int value = 75000;
            var expectedZip = "93140";
            var expectedCity = "Bondy";

            var scrambler = new AddressScrambler(salt);
            scrambler.Properties.Add("pattern", "{out:zipcode}");
            scrambler.Properties.Add("seed", "someseed");

            var scrambler2 = new AddressScrambler(salt);
            scrambler2.Properties.Add("pattern", "{out:city}");
            scrambler2.Properties.Add("seed", "someseed");

            var scrambler3 = new AddressScrambler(salt);
            scrambler3.Properties.Add("pattern", "{out:zipcode} {out:city}");
            scrambler3.Properties.Add("seed", "someseed");

            var zip = scrambler.Scramble(value.ToString(), null);
            var city = scrambler2.Scramble(value.ToString(), null);
            var fullZip = scrambler2.Scramble(value.ToString(), null); ;

            Assert.Equal(expectedZip, zip);
            Assert.Equal(expectedCity, city);
            Assert.Equal(expectedZip + " " + expectedCity, fullZip);
        }
    }
}
