using Cntrls;
using Collections;
using Settings;
using UnityEngine;
using Zenject;

namespace SceneCntrls
{
    public class RoundsEditorCntrl : MonoBehaviour
    {
        public Transform RoundList;
        public RoundView RoundViewPrefab;
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
        
        public void OnClickAddRoundBtn()
        {
            _sceneNavigator.GoToNextScene("AddRoundScene");
        }
        
        public void OnClickShowGroupBtn()
        {
            _sceneNavigator.GoToNextScene("ShowGroupScene");
        }
        
        public void OnClickDeleteLastBtn()
        {
            if (_temp.GroupItem.RoundCntrlList.Count > 0)
            {
                _temp.GroupItem.DeleteLastFigureItem();
            }

            UpdateRoundsList();
        }

        private void UpdateRoundsList()
        {
            DeleteALlChildrenInList();
            foreach (var roundCntrl in _temp.GroupItem.RoundCntrlList)
            {
                var roundView = Instantiate(RoundViewPrefab, RoundList);
                roundView.InitialzieRoundCntrl(roundCntrl, _spritesCollection);
            }
        }
        private void Start()
        {
            UpdateRoundsList();
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