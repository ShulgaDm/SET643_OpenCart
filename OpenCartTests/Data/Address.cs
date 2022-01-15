using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Data
{
    public class Address
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress1 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string RegionState { get; set; }

        public Address() { }
        public static AddressBuilder CreateBuilder()
        {
            return new AddressBuilder();
        }
    }
}
