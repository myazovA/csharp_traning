using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData modContact = new ContactData();
            modContact.Firstname = "John";
            modContact.Lastname = "Sus";

            app.Contacts.Modify(3, modContact);
        }
    }
}
