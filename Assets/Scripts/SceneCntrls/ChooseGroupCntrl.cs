using Settings;
using UnityEngine;
using Zenject;

namespace SceneCntrls
{
    public class ChooseGroupCntrl : MonoBehaviour
    {
        private SceneNavigator _sceneNavigator;
        [Inject]
        public void Construct(SceneNavigator sceneNavigator)
        {
            _sceneNavigator = sceneNavigator;
        }

        public void OnClickBackBtn()
        {
            _sceneNavigator.GoToBackScene();
        }
    }
}
