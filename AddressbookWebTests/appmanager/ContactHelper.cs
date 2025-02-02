using OpenQA.Selenium.Support.UI;
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
        public ContactHelper ConfirmAddContact()
        {
            ClickElementWithXPATH("//div[@id='content']/form/input[20]");
            return this;
        }
        public ContactHelper FillContactData(ContactData contact)
        {
            FillContactTextField("firstname", contact.Firstname);
            FillContactTextField("middlename", contact.Middlename);
            FillContactTextField("lastname", contact.Lastname);
            FillContactTextField("nickname", contact.Nickname);
            //FillContactTextField("photo", contact.Photo);
            FillContactTextField("title", contact.Title);
            FillContactTextField("company", contact.Company);
            FillContactTextField("address", contact.Address);
            FillContactTextField("home", contact.Home);
            FillContactTextField("mobile", contact.Mobile);
            FillContactTextField("work", contact.Work);
            FillContactTextField("fax", contact.Fax);
            FillContactTextField("email", contact.Email);
            FillContactTextField("email2", contact.Email2);
            FillContactTextField("email3", contact.Email3);
            FillContactTextField("homepage", contact.Homepage);
            /*FillContactTextField("bday", contact.Bday);
            FillContactListField("bmonth", contact.Bmonth);
            FillContactTextField("byear", contact.Byear);
            FillContactListField("aday", contact.Aday);
            FillContactListField("amonth", contact.Amonth);
            FillContactTextField("ayear", contact.Ayear);
            FillContactListField("new_group", contact.New_group);*/
            return this;
        }
        public ContactHelper FillContactListField(string fieldname, string number)
        {
            ClickElementWithName(fieldname);
            SelectElementFromList(fieldname, number);
            return this;
        }
        public ContactHelper FillContactTextField(string fieldname, string key)
        {
            ClickElementWithName(fieldname);
            ClearElementWithName(fieldname);
            SendKeysToElementWithName(fieldname, key);
            return this;
        }
    }
}
