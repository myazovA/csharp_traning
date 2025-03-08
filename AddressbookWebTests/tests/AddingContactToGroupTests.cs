using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            app.Contacts.CreateContactIfNotExist();
            app.Groups.CreateGroupIfNotExist();

            GroupData group = GroupData.GetAll()[0];
            ContactData contact;
            List<ContactData> oldList = group.GetContacts();
            List<ContactData> contacts = ContactData.GetAll();

            if (oldList.Count == contacts.Count)
            {
                app.Contacts.Create(new ContactData("Artem", "Myazov"));
                contact = ContactData.GetLast();
            }
            else
            {
                contact = ContactData.GetAll().Except(oldList).First();
            }

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
