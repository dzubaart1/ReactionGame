using System.Collections.Generic;

namespace Models
{
    public class LevelItemCollection
    {
        public List<LevelItem> LevelItems;

        public LevelItemCollection()
        {
            LevelItems = new List<LevelItem>();
        }

        public void AddLevelItem(LevelItem levelItem)
        {
            LevelItems.Add(levelItem);
        }

        public void DeleteLastItem()
        {
            LevelItems.RemoveAt(LevelItems.Count-1);
        }
    }
}