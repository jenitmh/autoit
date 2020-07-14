using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        private void AddGroup(GroupData newGroup)
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
        }

        public void CreateGroup(GroupData newGroup)
        {
            OpenGroupsDialogue();
            AddGroup(newGroup);
            CloseGroupsDialogue();
        }

        public void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void EditGroup(GroupData newGroup)
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d52");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(
                GROUPWINTITLE,
                "",
                "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount",
                "#0",
                "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                    GROUPWINTITLE,
                    "",
                    "WindowsForms10.SysTreeView32.app.0.2c908d51",
                    "GetText",
                    "#0|#" + i,
                    "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialogue();
            return list;
        }

        public void GroupCheck()
        {
            OpenGroupsDialogue();
            GroupData group = new GroupData()
            {
                Name = TestBase.GenerateRandomString(5)
            };
            string groups = aux.ControlTreeView(
                    GROUPWINTITLE,
                    "",
                    "WindowsForms10.SysTreeView32.app.0.2c908d51",
                    "Exists",
                    "#0|#1",
                    "");
            if (groups == "0")
            {
                CreateGroup(group);
            }
        }

        public void Modify(GroupData newData)
        {
            OpenGroupsDialogue();
            SelectGroup();
            EditGroup(newData);
            CloseGroupsDialogue();
        }

        public void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }

        public void Remove()
        {
            OpenGroupsDialogue();
            SelectGroup();
            RemoveGroup();
            CloseGroupsDialogue();
        }

        public void RemoveGroup()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait("Delete group");
            aux.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.WinWait(GROUPWINTITLE);
        }

        public void SelectGroup()
        {
            aux.ControlTreeView(
                    GROUPWINTITLE,
                    "",
                    "WindowsForms10.SysTreeView32.app.0.2c908d51",
                    "Select",
                    "#0|#0",
                    "");
        }
    }
}