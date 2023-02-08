using Cntrls;
using Data;
using Models;
using Settings;
using UnityEngine;
using Zenject;

namespace SceneCntrls
{
    public class LevelsEditorCntrl : MonoBehaviour
    {
        public Transform TimeTable;
        public LevelItemPrefabCntrl LevelItemPrefabCntrl;
        private LevelItemCollection _levelItemCollection;
        private SceneNavigator _sceneNavigator;
    
        [Inject]
        public void Construct(LevelItemCollection levelItemCollection, SceneNavigator sceneNavigator)
        {
            _levelItemCollection = levelItemCollection;
            _sceneNavigator = sceneNavigator;
        }
        private void Start()
        {
            UpdateList();
        }

        private void UpdateList()
        {
            DeleteALlChildrenInList();
            foreach (var levelItem in _levelItemCollection.LevelItems)
            {
                LevelItemPrefabCntrl temp = Instantiate(LevelItemPrefabCntrl, TimeTable);
                temp.InitializeLeveItem(levelItem);
            }
        }
        public void OnClickAddBtn()
        {
            _sceneNavigator.GoToNextScene("AddLevelScene");
        }
    
        public void OnClickDeleteLastBtn()
        {
            _levelItemCollection.DeleteLastItem();
            UpdateList();
        }
    
        public void OnClickSaveBtn()
        {
            JsonStorage.Save(_levelItemCollection);
        }

        public void OnClickMainMenuBtn()
        {
            _sceneNavigator.GoToNextScene("MainMenu");
        }
        private void DeleteALlChildrenInList()
        {
            for (int i = 0; i < TimeTable.childCount; i++)
            {
                Destroy(TimeTable.GetChild(i).gameObject);
            }
        }
    }
}
