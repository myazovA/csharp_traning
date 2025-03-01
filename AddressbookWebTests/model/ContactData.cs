using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string contactDetails;
        private int phoneCounter = 0;
        private int mailCounter = 0;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }

        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Email + "\r\n" + Email2 + "\r\n" + Email3).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        public string Homepage { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Aday { get; set; }
        public string Amonth { get; set; }
        public string Ayear { get; set; }
        public string New_group { get; set; }
        public string Id { get; set; }
        public string detailsName { get; set; }
        public string detailsPhone { get; set; }

        public int CompareTo(ContactData other)
        {
            if (other == null)
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) != 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            else
            {
                return Firstname.CompareTo(other.Firstname);
            }
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(other, this))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }
        public override string ToString()
        {
            return Firstname + " " + Lastname;
        }
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
        public string ContactDetails
        {
            get
            {
                return
                    (NotExistCheck(Firstname) + NotExistCheck(Middlename) + NotExistCheck(Lastname)
                    + NotExistCheck(Nickname)
                    + NotExistCheck(Title)
                    + NotExistCheck(Company)
                    + NotExistCheck(Address)
                    + "\r\n"
                    + NotExistCheck(Home)
                    + NotExistCheck(Mobile)
                    + NotExistCheck(Work)
                    + NotExistCheck(Fax)
                    + EmptyRow(phoneCounter)
                    + NotExistCheck(Email)
                    + NotExistCheck(Email2)
                    + NotExistCheck(Email3)
                    + NotExistCheck(Homepage)
                    + EmptyRow(mailCounter)
                    + NotExistDateCheck(Bday, Bmonth, Byear)
                    + NotExistDateCheck(Aday, Amonth, Ayear)
                    ).Trim();
            }
            set
            {
                contactDetails = value;
            }
        }
        public string NotExistCheck(string element)
        {
            if (element != null && element != "")
            {
                if (element == Firstname || element == Middlename)
                {
                    return element + " ";
                }
                if (element == Home)
                {
                    phoneCounter += 1;
                    return "H: " + element + "\r\n";
                }
                if (element == Mobile)
                {
                    phoneCounter += 1;
                    return "M: " + element + "\r\n";
                }
                if (element == Work)
                {
                    phoneCounter += 1;
                    return "W: " + element + "\r\n";
                }
                if (element == Fax)
                {
                    phoneCounter += 1;
                    return "F: " + element + "\r\n";
                }
                if (element == Email || element == Email2 || element == Email3)
                {
                    mailCounter += 1;
                    return element + "\r\n";
                }
                if (element == Homepage)
                {
                    mailCounter += 1;
                    return "Homepage:\r\n" + element + "\r\n";
                }
                else
                {
                    return element + "\r\n";
                }
            }
            return "";
        }
        public string NotExistDateCheck(string day, string month, string year)
        {
            if (day != null && day != "" && day != "0")
            {
                if (day == Aday)
                {
                    int intAyear = int.Parse(Ayear);
                    string age = (DateTime.Now.Year - intAyear).ToString();
                    return "Anniversary " + Aday + ". " + Amonth + " " + Ayear + " (" + age + ")";
                }
                if (day == Bday)
                {
                    return "Birthday " + Bday + ". " + Bmonth + " " + Byear + "\r\n";
                }
            }
            return "";
        }
        public string EmptyRow(int Counter)
        {
            if (Counter >= 1)
            {
                return "\r\n";
            }
            return "";
        }
    }
}
