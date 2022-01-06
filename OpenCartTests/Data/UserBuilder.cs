using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTests.Data
{
    public class UserBuilder
    {
        private User user;
        public UserBuilder()
        {
            user = new User();
        }
        public UserBuilder SetFirstName(string firstName)
        {
            user.FirstName = firstName;
            return this;
        }
        public UserBuilder SetLastName(string lastName)
        {
            user.LastName = lastName;
            return this;
        }
        public UserBuilder SetEMail(string email)
        {
            user.EMail = email;
            return this;
        }
        public UserBuilder SetTelephone(string telephone)
        {
            user.Telephone = telephone;
            return this;
        }
        public UserBuilder SetMainAdress(string adress)
        {
            user.MainAdress = adress;
            return this;
        }
        public UserBuilder SetCity(string city)
        {
            user.City = city;
            return this;
        }
        public UserBuilder SetPostCode(string code)
        {
            user.PostCode = code;
            return this;
        }
        public UserBuilder SetCountry(string country)
        {
            user.Country = country;
            return this;
        }
        public UserBuilder SetRegionState(string regionState)
        {
            user.RegionState = regionState;
            return this;
        }
        public UserBuilder SetPassword(string password)
        {
            user.Password = password;
            return this;
        }
        public UserBuilder SetFax(string fax)
        {
            user.Fax = fax;
            return this;
        }
        public UserBuilder SetCompany(string company)
        {
            user.Company = company;
            return this;
        }
        public UserBuilder SetAdress(string adress)
        {
            user.Address = adress;
            return this;
        }
        public UserBuilder SetSubscribe(bool subscribe)
        {
            user.Subscribe = subscribe;
            return this;
        }
        public User Build()
        {
            return user;
        }
    }
}
