using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData()
            {
                Name = GenerateRandomString(5) + "(Edit)",
            };

            app.Groups.GroupCheck();

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData toBeModified = oldGroups[0];

            app.Groups.Modify(newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            toBeModified.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
