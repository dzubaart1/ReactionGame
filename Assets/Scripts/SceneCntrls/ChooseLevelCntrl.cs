using Models;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SceneCntrls
{
    public class ChooseLevelCntrl : MonoBehaviour
    {
        public Transform BtnsList;
        public GameObject ItemBtnPrefab;
        private Temp _settings;
        private LevelItemCollection _levelItemCollection;
        private SceneNavigator _sceneNavigator;
        [Inject]
        public void Construct(Temp settings, LevelItemCollection levelItemCollection,SceneNavigator sceneNavigator)
        {
            _settings = settings;
            _levelItemCollection = levelItemCollection;
            _sceneNavigator = sceneNavigator;
        }

        private void Start()
        {
            foreach (var levelItem in _levelItemCollection.LevelItems)
            {
                var temp = Instantiate(ItemBtnPrefab, BtnsList);
                temp.GetComponentInChildren<Text>().text = levelItem.Name;
                temp.GetComponentInChildren<Button>().onClick.AddListener(() =>
                {
                    _settings.LevelItem = levelItem;
                    _sceneNavigator.GoToNextScene("ShowInstructionScene");
                });
            }
        }

        public void OnClickBackBtn()
        {
            _sceneNavigator.GoToBackScene();
        }
    }
}
