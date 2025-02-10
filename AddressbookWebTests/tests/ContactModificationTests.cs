using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.CreateContactIfNotExist();

            ContactData modContact = new ContactData();
            modContact.Firstname = "John";
            modContact.Lastname = "Sus";

            app.Contacts.Modify(2, modContact);
        }
    }
}
