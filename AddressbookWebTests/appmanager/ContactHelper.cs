using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddContact();
            FillContactData(contact);
            ConfirmAddContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper Modify(int num, ContactData contact)
        {   
            GoToEditContact(num);
            FillContactData(contact);
            ConfirmEditContact();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        public ContactHelper Remove(int num)
        {
            ChooseContact(num);
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }
        public void CreateContactIfNotExist()
        {
            if (!IsElementPresent(By.XPath("//tr[2]/td[8]/a/img")))
            {
                ContactData baseContact = new ContactData("Artem", "Myazov");
                Create(baseContact);
            }
        }

        public ContactHelper ChooseContact(int num)
        {
            ClickElementWithXPATH("//tr[" + (num+2) + "]/td/input");
            return this;
        }
        public ContactHelper RemoveContact()
        {
            ClickElementWithXPATH("//input[@value='Delete']");
            contactCache = null;
            return this;
        }
        public ContactHelper ConfirmEditContact()
        {
            ClickElementWithXPATH("//div[@id='content']/form/input[21]");
            contactCache = null;
            return this;
        }
        public ContactHelper GoToEditContact(int num)
        {
            ClickElementWithXPATH("//tr[" + (num + 2) + "]/td[8]/a/img");
            return this;
        }
        public ContactHelper ConfirmAddContact()
        {
            ClickElementWithXPATH("//div[@id='content']/form/input[20]");
            contactCache = null;
            return this;
        }
        public ContactHelper FillContactData(ContactData contact)
        {
            Type("firstname", contact.Firstname);
            Type("firstname", contact.Firstname);
            Type("middlename", contact.Middlename);
            Type("lastname", contact.Lastname);
            Type("nickname", contact.Nickname);
            Type("photo", contact.Photo);
            Type("title", contact.Title);
            Type("company", contact.Company);
            Type("address", contact.Address);
            Type("home", contact.Home);
            Type("mobile", contact.Mobile);
            Type("work", contact.Work);
            Type("fax", contact.Fax);
            Type("email", contact.Email);
            Type("email2", contact.Email2);
            Type("email3", contact.Email3);
            Type("homepage", contact.Homepage);
            FillContactListField("bday", contact.Bday);
            FillContactListField("bmonth", contact.Bmonth);
            Type("byear", contact.Byear);
            FillContactListField("aday", contact.Aday);
            FillContactListField("amonth", contact.Amonth);
            Type("ayear", contact.Ayear);
            FillContactListField("new_group", contact.New_group);
            return this;
        }
        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                List<ContactData> contacts = new List<ContactData>();
                ICollection<IWebElement> rows = driver.FindElements(By.Name("entry"));
                foreach (IWebElement row in rows)
                {
                    IList<IWebElement> cells = row.FindElements(By.TagName("td"));
                    string lastName = cells[1].Text;
                    string firstName = cells[2].Text;

                    contactCache.Add(new ContactData(firstName, lastName)
                    {
                        Id = row.FindElement(By.TagName("input")).GetAttribute("id")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            GoToEditContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }
    }
}
