using System.Collections.Generic;
using System.Security.Cryptography;
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
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0, modContact);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Firstname = modContact.Firstname;
            oldContacts[0].Lastname = modContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in oldContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(modContact.Firstname, contact.Firstname);
                }
            }
        }
    }
}
