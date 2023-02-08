using System.Collections.Generic;
using Models;

namespace Collections
{
    public class GroupItemCollection
    {
        public List<GroupItem> GroupItems;
        public GroupItemCollection()
        {
            GroupItems = new List<GroupItem>();
        }

        public void AddGroupItem(GroupItem groupItem)
        {
            GroupItems.Add(groupItem);
        }

        public void DeleteGroupItem(GroupItem groupItem)
        {
            GroupItems.Remove(groupItem);
        }
        
    }
}