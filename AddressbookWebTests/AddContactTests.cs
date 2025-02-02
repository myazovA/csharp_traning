using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddContactTests : TestBase
    {
        [Test]
        public void AddContactWithFirstAndLastName()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddContact();
            ContactData contact = new ContactData();
            contact.Firstname = "Artem";
            contact.Lastname = "Myazov";
            FillContactData(contact);
            ConfirmAddContact();
            ReturnToHomePage();
        }
    }
}
