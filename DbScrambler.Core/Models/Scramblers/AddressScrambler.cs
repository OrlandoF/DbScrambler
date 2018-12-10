using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CsvHelper;

namespace DbScrambler.Core.Models.Scramblers
{
    public class AddressScrambler : BaseScrambler
    {
        List<ZipCode> _zipCodes;
        const string _pattern = "pattern";
        const string _seed = "seed";

        public AddressScrambler(string salt) : base(salt)
        {
            IsValid();
        }
        public override object Scramble(object value, Dictionary<string, string> fields)
        {
            string response;
            Dictionary<string, string> zip = new Dictionary<string, string>();
            var index = CreateNumberFromString(this.Salt + value) % _zipCodes.Count();
            zip.Add("zipcode", _zipCodes.ElementAt(index).Zip);
            zip.Add("city", _zipCodes.ElementAt(index).City);
            response = this.GetOutput(Properties[_pattern], value.ToString(), fields, zip);
            return response;
        }

        public override bool IsValid()
        {
            bool isValid = true;
            Errors.Clear();
            try
            {
                _zipCodes = LoadZipCodes();
            }
            catch (Exception ex)
            {
                isValid = false;
                //TODO use logger
                Console.WriteLine("Unable to load address csv file; "+ex.Message);
                Console.WriteLine(ex.ToString());
                Errors.Add("Unable to load address csv file");
            }
            if (!Properties.ContainsKey(_pattern))
            {
                isValid = false;
                Errors.Add("Missing pattern property");
            }

            if (!Properties.ContainsKey(_seed))
            {
                isValid = false;
                Errors.Add("Missing seed property");
            }
            return isValid;
        }

        private List<ZipCode> LoadZipCodes()
        {
            List<ZipCode> zipCodes;
            using (StreamReader sr = new StreamReader(GetFilePath()))
            {
                
                var csv = new CsvReader(sr);
                csv.Configuration.Delimiter = ";";
                var result = csv.GetRecords<ZipCode>();
                zipCodes = result.ToList<ZipCode>();
            }
            return zipCodes;
        }
        private string GetFilePath()
        {
            return ".\\Models\\Scramblers\\Address\\address.csv";
        }

        private int CreateNumberFromString(string value)
        {
            MD5 md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(value));
            var ivalue = BitConverter.ToInt32(hashed, 0);
            return System.Math.Abs(ivalue);
        }

    }

    class ZipCode
    {
        public string Zip { get; set; }
        public string City { get; set; }

    }
}
