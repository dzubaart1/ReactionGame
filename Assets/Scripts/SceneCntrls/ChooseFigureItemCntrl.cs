using Collections;
using Settings;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace SceneCntrls
{
    public class ChooseFigureItemCntrl : MonoBehaviour
    {
        public Transform FigureItemBtnsList;
        public GameObject FigureItemBtnPrefab;
        private Temp _temp;
        private SpritesCollection _spritesCollection;
        private SceneNavigator _sceneNavigator;
        [Inject]
        public void Construct(Temp temp, SpritesCollection spritesCollection, SceneNavigator sceneNavigator)
        {
            _temp = temp;
            _sceneNavigator = sceneNavigator;
            _spritesCollection = spritesCollection;
        }

        private void Start()
        {
            foreach (var figureItem in _temp.GroupItem.BaseFigureItems)
            {
                var obj = Instantiate(FigureItemBtnPrefab, FigureItemBtnsList);
                obj.GetComponentInChildren<Button>().onClick.AddListener(() =>
                {
                    _temp.FigureItem = figureItem;
                    _sceneNavigator.GoToNextScene("ChooseLevelScene");
                });
                obj.GetComponentInChildren<Image>().sprite = _spritesCollection.FindSpriteByName(figureItem.SpriteName);
            }
        }

        public void OnClickBackBtn()
        {
            _sceneNavigator.GoToBackScene();
        }
    }
}
