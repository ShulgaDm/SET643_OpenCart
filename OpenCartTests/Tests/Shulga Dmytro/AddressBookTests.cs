using NUnit.Framework;
using OpenCartTests.Data;
using OpenCartTests.Pages;
using OpenCartTests.Tools;

namespace OpenCartTests.Tests.Shulga_Dmytro
{
    [TestFixture]
    public class AddressBookTests : TestRunner
    {
        protected override string OpenCartURL { get => "http://cart"; }
        public readonly string LOGIN_URL = "index.php?route=account/login";
        public readonly string ADDRESS_BOOK_URL = "index.php?route=account/address";
        public readonly string EXPECTED_SUCCESSFULL_ADD_ADDRESS_MESSAGE = 
                                        "Your address has been successfully added";

        User user;
        Address address;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            user = User.CreateBuilder()
                        .SetEMail("email@email.com")
                        .SetPassword("123456").Build();

            address = Address.CreateBuilder()
                                .SetFirstName("Ivan")
                                .SetLastName("Ivanov")
                                .SetAdress1("Street")
                                .SetCity("Kyiv")
                                .SetPostCode("777")
                                .SetCountry("Ukraine")
                                .SetRegionState("Kyiv").Build();
        }

        [Test]
        public void UnloggedClickAddressBookButton()
        {
            string expected = LOGIN_URL;

            string actual = new HomePage(driver)
                                    .GoToLoginPage()
                                    .unloggedClickAddressBookButton()
                                    .GetURLLoginPage();

            Assert.IsTrue(actual.Contains(expected));
        }

        [Test]
        public void LoggedClickAddressBookButton()
        {
            string expected = ADDRESS_BOOK_URL;

            string actual = new HomePage(driver)
                                    .GoToLoginPage()
                                    .SuccessfullLogin(user)
                                    .GoToAddressBookPage()
                                    .GetURLAddressBookPage();

            Assert.IsTrue(actual.Contains(expected));
        }

        [Test]
        public void SuccessfullAddNewAddressTest()
        {
            string expected = EXPECTED_SUCCESSFULL_ADD_ADDRESS_MESSAGE;

            string actual = new HomePage(driver)
                                    .GoToLoginPage()
                                    .SuccessfullLogin(user)
                                    .GoToAddressBookPage()
                                    .GoToAddAddressPage()
                                    .SuccessfullAddNewAddress(address)
                                    .GetAlertMessageText();

            Assert.AreEqual(expected, actual);
        }
    }
}
