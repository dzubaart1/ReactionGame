using Collections;
using Models;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Cntrls
{
    public class FigureItemListCntrl : MonoBehaviour
    {
        public Transform FigureItemList;
        public GameObject FigureItemPrefab;
        private SpritesCollection _spritesCollection;
    
        [Inject]
        public void Construct(SpritesCollection spritesCollection)
        {
            _spritesCollection = spritesCollection;
        }
        public void InitializeFigureItems(GroupItem groupItem)
        {
            foreach (var figureItem in groupItem.BaseFigureItems)
            {
                var obj = Instantiate(FigureItemPrefab, FigureItemList);
                obj.GetComponentInChildren<Image>().sprite = _spritesCollection.FindSpriteByName(figureItem.SpriteName);
                obj.GetComponentInChildren<Text>().text = figureItem.KeyCode;
            }
        }
    }
}
