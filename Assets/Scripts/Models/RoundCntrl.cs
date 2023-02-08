using System.Collections.Generic;

namespace Models
{
    public class RoundCntrl
    {
        private List<FigureItem> _figureItems;

        public RoundCntrl()
        {
            _figureItems = new List<FigureItem>();
        }
        
        public IReadOnlyCollection<FigureItem> FigureItems => _figureItems;

        public void AddFigureItem(FigureItem figureItem)
        {
            _figureItems.Add(figureItem);
        }

        public void ClearList()
        {
            _figureItems.Clear();
        }

        public FigureItem GetFigireItemById(int id)
        {
            return _figureItems[id];
        }
    }
}