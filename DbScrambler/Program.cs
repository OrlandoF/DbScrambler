using DbScrambler.Core.Models;
using DbScrambler.Core.Models.Scramblers;
using DbScrambler.Core.Services;
using System;

namespace DbScrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WriteSampleProfile();
        }

        static void WriteSampleProfile()
        {
            ProfileService psrv = new ProfileService();
            Profile profile = new Profile {ConnectionString="Server=;User=;Password=;Database=;"
            , Seed="myseed"};

            var scrambler = new EmailScrambler(profile.Seed);
            scrambler.Properties.Add("prop1", "value1");
            scrambler.Properties.Add("prop2", DateTime.Now.ToString());
            profile.Scramblers.Add("sample", scrambler);

            profile.Tables.Add(new Table
            {
                Name = "table1",
                Fields = { new Field { Name = "field1", ScramblerName = "sample" }, new Field { Name = "field2", ScramblerName = "sample" } }
            });
            profile.Tables.Add(new Table
            {
                Name = "table2",
                Fields = { new Field { Name = "field1", ScramblerName = "sample" }, new Field { Name = "field2", ScramblerName = "sample" } }
            });

            psrv.Save("SampleProfile", profile);
        }
    }
}
