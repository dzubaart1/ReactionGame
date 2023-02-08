using System.Collections.Generic;

namespace Models
{
    public class GroupItem
    {
        private const int MAXFIGUREITEMSCOUNT = 15;
        public string Name;
        public int Count;
        public List<FigureItem> BaseFigureItems;
        public List<RoundCntrl> RoundCntrlList;
        public string Instruction;
        public string KeyCodeSingleMode;
        public bool IsSingleMode;
        public GroupItem(string name,string instruction, int count)
        {
            Name = name;
            Count = count;
            Instruction = instruction;
            IsSingleMode = false;
            KeyCodeSingleMode = "None";
            
            BaseFigureItems = new List<FigureItem>();
            RoundCntrlList = new List<RoundCntrl>();
        }

        public void SetKeyCodeSingleMode(string keyCode)
        {
            KeyCodeSingleMode = keyCode;
            IsSingleMode = true;
        }
        public void AddFigureItem(FigureItem figureItem)
        {
            BaseFigureItems.Add(figureItem);
        }

        public void DeleteLastFigureItem()
        {
            RoundCntrlList.RemoveAt(RoundCntrlList.Count-1);
        }

        public int GetNextPos()
        {
            return BaseFigureItems.Count+1;
        }

        public bool IsEnoughItems()
        {
            return Count == BaseFigureItems.Count;
        }
    }
}