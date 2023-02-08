using Collections;
using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Cntrls
{
    public class RoundView : MonoBehaviour
    {
        public Transform RoundList;
        public RoundCntrl RoundCntrl;
        private SpritesCollection _spritesCollection;

        public void InitialzieRoundCntrl(RoundCntrl roundCntrl, SpritesCollection spritesCollection)
        {
            RoundCntrl = roundCntrl;
            _spritesCollection = spritesCollection;
            UpdateList();
        }

        public void AddFigureItem(FigureItem figureItem)
        {
            RoundCntrl.AddFigureItem(figureItem);
            UpdateList();
        }
        public void ClearList()
        {
            RoundCntrl.ClearList();
            UpdateList();
        }

        public int GetCountFigureItems()
        {
            return RoundCntrl.FigureItems.Count;
        }
        private void UpdateList()
        {
            DeleteALlChildrenInList();
            foreach (var figureItem in RoundCntrl.FigureItems)
            {
                var gameObject = new GameObject();
                gameObject.AddComponent<Image>().sprite = _spritesCollection.FindSpriteByName(figureItem.SpriteName);
                gameObject.transform.SetParent(RoundList);
                gameObject.GetComponent<Image>().rectTransform.localScale = new Vector3(1, 1, 1);
            }
        }

        private void DeleteALlChildrenInList()
        {
            for (int i = 0; i < RoundList.childCount; i++)
            {
                Destroy(RoundList.GetChild(i).gameObject);
            }
        }
    }
}