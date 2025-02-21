

using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
        public string Middlename {  get; set; }
        public string Lastname {  get; set; }
        public string Nickname {  get; set; }
        public string Photo {  get; set; }
        public string Title {  get; set; }
        public string Company {  get; set; }
        public string Address {  get; set; }
        public string Home {  get; set; }
        public string Mobile {  get; set; }
        public string Work {  get; set; }
        public string Fax {  get; set; }
        public string Email {  get; set; }
        public string Email2 {  get; set; }
        public string Email3 {  get; set; }
        public string Homepage {  get; set; }
        public string Bday {  get; set; }
        public string Bmonth {  get; set; }
        public string Byear {  get; set; }
        public string Aday {  get; set; }
        public string Amonth {  get; set; }
        public string Ayear {  get; set; }
        public string New_group {  get; set; }
        public string Id { get; set; }

        public int CompareTo(ContactData other)
        {
            if (other == null)
            {
                return 1;
            }
            return Firstname.CompareTo(other.Firstname) + Lastname.CompareTo(other.Lastname);
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
            return  Firstname + " " + Lastname;
        }
    }
}
