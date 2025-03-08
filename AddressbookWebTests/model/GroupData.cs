﻿using System;
using LinqToDB.Mapping;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData()
        {
        }

        public GroupData(string name)
        {
            Name = name;
        }
        [Column(Name = "group_name")]
        public string Name { get; set; }
        [Column(Name = "group_header")]
        public string Header { get; set; }
        [Column(Name = "group_footer")]
        public string Footer { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }
        public int CompareTo(GroupData other)
        {
            if (other == null)
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
        public bool Equals(GroupData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(other, this))
            {
                return true;
            }
            return Name == other.Name;
        }
        public override int GetHashCode()
        { 
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + Name;
        }
        public static List<GroupData> GetAll()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }
    }
}
