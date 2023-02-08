using Collections;
using Data;
using Settings;
using UnityEngine;
using Zenject;

namespace SceneCntrls
{
    public class GroupsEditorCntrl : MonoBehaviour
    {
        private GroupItemCollection _groupItemCollection;
        private SceneNavigator _sceneNavigator;
        [Inject]
        public void Construct(GroupItemCollection groupItemCollection, SceneNavigator sceneNavigator)
        {
            _groupItemCollection = groupItemCollection;
            _sceneNavigator = sceneNavigator;
        }
        
        public void OnClickAddGroupBtn()
        {
            _sceneNavigator.GoToNextScene("CreateGroupItemScene");
        }

        public void OnClickMainMenuBtn()
        {
            _sceneNavigator.GoToNextScene("MainMenu");
        }
        
        public void OnClickSaveBtn()
        {
            JsonStorage.Save(_groupItemCollection);
        }
    }
}
