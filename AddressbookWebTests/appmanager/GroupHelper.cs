﻿using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }
        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            ChooseGroup(group.Id);
            DeleteGroup();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }
        public GroupHelper Modify(GroupData group, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            ChooseGroup(group.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.ReturnToGroupPage();
            return this;
        }

        public void CreateGroupIfNotExist()
        {
            manager.Navigator.GoToGroupPage();
            if (!IsElementPresent(By.XPath("//div[@id='content']/form/span/input")))
            {
                GroupData baseGroup = new GroupData("0");
                Create(baseGroup);
            }
        }
        public GroupHelper SubmitGroupModification()
        {
            ClickElementWithName("update");
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            ClickElementWithName("edit");
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            ClickElementWithName("submit");
            groupCache = null;
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type("group_name", group.Name);
            Type("group_header", group.Header);
            Type("group_footer", group.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            ClickElementWithName("new");
            return this;
        }
        public GroupHelper DeleteGroup()
        {
            ClickElementWithName("delete");
            groupCache = null;
            return this;
        }
        public GroupHelper ChooseGroup(string id)
        {
            ClickElementWithXPATH("//input[@name='selected[]' and @value='" + id + "']");
            return this;
        }
        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(groupCache);
        }
        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
