using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void AddContactWithFirstAndLastName()
        {
            ContactData contact = new ContactData();
            contact.Firstname = "Artem";
            contact.Lastname = "Myazov";

            app.Contacts.Create(contact);
        }
        [Test]
        public void AddContactWithFirstLastNameAndAData()
        {
            ContactData contact = new ContactData();
            contact.Firstname = "Artem";
            contact.Lastname = "Myazov";
            contact.Amonth = "January";
            contact.Ayear = "2000";
            contact.Aday = "1";

            app.Contacts.Create(contact);
        }
    }
}
