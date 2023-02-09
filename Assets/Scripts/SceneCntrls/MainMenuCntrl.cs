using Settings;
using UnityEngine;
using Zenject;

namespace SceneCntrls
{
    public class MainMenuCntrl : MonoBehaviour
    {
        private SceneNavigator _sceneNavigator;
        [Inject]
        public void Construct(SceneNavigator sceneNavigator)
        {
            _sceneNavigator = sceneNavigator;
        }

        public void OnClickPlayBtn()
        {
            _sceneNavigator.GoToNextScene("ChooseGroupScene");
        }

        public void OnClickGroupsEditorBtn()
        {
            _sceneNavigator.GoToNextScene("GroupsEditor");
        }

        public void OnClickLevelsEditorBtn()
        {
            _sceneNavigator.GoToNextScene("LevelsEditorScene");
        }

        public void OnClickExitBtn()
        {
            Application.Quit();
        }
    }
}
