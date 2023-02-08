using Cntrls;
using Collections;
using Models;
using Settings;
using UnityEngine;
using Zenject;

namespace SceneCntrls
{
    public class AddRoundCntrl : MonoBehaviour
    {
        private const int MAXCOUNTFIGUREITEM = 13;
        public FigureItemListCntrl FigureItemListCntrl;
        public RoundView RoundView;
        private Temp _temp;
        private SpritesCollection _spritesCollection;
        private SceneNavigator _sceneNavigator;

        [Inject]
        public void Construct(Temp temp, SpritesCollection spritesCollection, SceneNavigator sceneNavigator)
        {
            _temp = temp;
            _spritesCollection = spritesCollection;
            _sceneNavigator = sceneNavigator;
        }
        private void Start()
        {
            RoundView.InitialzieRoundCntrl(new RoundCntrl(), _spritesCollection);
            FigureItemListCntrl.InitializeFigureItems(_temp.GroupItem);
        }

        private void Update()
        {
            if (!Input.anyKeyDown) return;
            var figureItem =
                _temp.GroupItem.BaseFigureItems.Find(figureItem =>
                    Input.inputString.Equals(figureItem.KeyCode));
            if (figureItem is not null && RoundView.RoundCntrl.FigureItems.Count <= MAXCOUNTFIGUREITEM)
            {
                RoundView.AddFigureItem(figureItem);
            }
        }
    
        public void OnDoneBtnClick()
        {
            if (RoundView.GetCountFigureItems() == 0)
            {
                return;
            }
            _temp.GroupItem.RoundCntrlList.Add(RoundView.RoundCntrl);
            _sceneNavigator.GoToNextScene("RoundsEditorScene");
        }

        public void OnResetBtnClick()
        {
            RoundView.ClearList();
        }
    }
}
