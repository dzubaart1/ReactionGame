using Collections;
using Data;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SceneCntrls
{
    public class GroupsEditorCntrl : MonoBehaviour
    {
        public GameObject GroupBtnPrefab;
        public Transform GroupsList;
        private GroupItemCollection _groupItemCollection;
        private SceneNavigator _sceneNavigator;
        private Temp _temp;

        [Inject]
        public void Construct(GroupItemCollection groupItemCollection, SceneNavigator sceneNavigator, Temp temp)
        {
            _groupItemCollection = groupItemCollection;
            _sceneNavigator = sceneNavigator;
            _temp = temp;
        }

        private void Start()
        {
            foreach (var groupItem in _groupItemCollection.GroupItems)
            {
                var obj = Instantiate(GroupBtnPrefab, GroupsList);
                obj.GetComponentInChildren<Button>().onClick.AddListener(() =>
                {
                    _temp.GroupItem = groupItem;
                    _sceneNavigator.GoToNextScene("ShowGroupScene");
                });
                obj.GetComponentInChildren<Text>().text = groupItem.Name;
            }
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
