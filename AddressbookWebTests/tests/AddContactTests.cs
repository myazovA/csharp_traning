using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddContactTests : TestBase
    {
        [Test]
        public void AddContactWithFirstAndLastName()
        {
            ContactData contact = new ContactData();
            contact.Firstname = "Artem";
            contact.Lastname = "Myazov";

            app.Contacts.Create(contact);
        }
    }
}
