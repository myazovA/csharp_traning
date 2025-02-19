using System.Collections.Generic;
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

            ContactData modContact = new ContactData("John", "Sus");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(0, modContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Firstname = "John";
            oldContacts[0].Lastname = "Sus";
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
