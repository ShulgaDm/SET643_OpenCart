using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Data
{
    public class AddressBuilder
    {
        private Address address;
        public AddressBuilder()
        {
            address = new Address();
        }
        public AddressBuilder SetFirstName(string firstName)
        {
            address.FirstName = firstName;
            return this;
        }
        public AddressBuilder SetLastName(string lastName)
        {
            address.LastName = lastName;
            return this;
        }
        public AddressBuilder SetAdress1(string adress1)
        {
            address.Adress1 = adress1;
            return this;
        }
        public AddressBuilder SetCity(string city)
        {
            address.City = city;
            return this;
        }
        public AddressBuilder SetPostCode(string code)
        {
            address.PostCode = code;
            return this;
        }
        public AddressBuilder SetCountry(string country)
        {
            address.Country = country;
            return this;
        }
        public AddressBuilder SetRegionState(string regionState)
        {
            address.RegionState = regionState;
            return this;
        }
        public Address Build()
        {
            return address;
        }
    }
}
