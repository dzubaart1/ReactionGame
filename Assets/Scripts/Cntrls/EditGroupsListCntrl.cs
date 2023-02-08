using Collections;
using Models;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Cntrls
{
    public class EditGroupsListCntrl : MonoBehaviour
    {
        public Transform GroupsList;
        public GameObject GroupBtnPrefab;
        private GroupItemCollection _groupItemCollection;
        private Temp _settings;
        private SceneNavigator _sceneNavigator;
        private string _loadScene;

        [Inject]
        public void Construct(GroupItemCollection groupItemCollection, Temp settings, SceneNavigator sceneNavigator)
        {
            _sceneNavigator = sceneNavigator;
            _groupItemCollection = groupItemCollection;
            _settings = settings;
        }
        private void Start()
        {
            foreach (var groupItem in _groupItemCollection.GroupItems)
            {
                var obj = Instantiate(GroupBtnPrefab, GroupsList);
                obj.GetComponentInChildren<Button>().onClick.AddListener(() =>
                {
                    _settings.GroupItem = groupItem;
                    _sceneNavigator.GoToNextScene("ShowGroupScene");
                });
                obj.GetComponentInChildren<Text>().text = groupItem.Name;
            }
        }
    }
}
