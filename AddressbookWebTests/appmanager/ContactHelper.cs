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
            return this;
        }
        public void CreateContactIfNotExist()
        {
            if (!IsElementPresent(By.XPath("//tr[2]/td[8]/a/img")))
            {
                ContactData baseContact = new ContactData();
                baseContact.Firstname = "Artem";
                Create(baseContact);
            }
        }

        public ContactHelper ChooseContact(int num)
        {
            ClickElementWithXPATH("//tr[" + num + "]/td/input");
            return this;
        }
        public ContactHelper RemoveContact()
        {
            ClickElementWithXPATH("//input[@value='Delete']");
            return this;
        }
        public ContactHelper ConfirmEditContact()
        {
            ClickElementWithXPATH("//div[@id='content']/form/input[21]");
            return this;
        }
        public ContactHelper GoToEditContact(int num)
        {
            ClickElementWithXPATH("//tr[" + num + "]/td[8]/a/img");
            return this;
        }
        public ContactHelper ConfirmAddContact()
        {
            ClickElementWithXPATH("//div[@id='content']/form/input[20]");
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
    }
}
