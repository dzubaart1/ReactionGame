using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SceneCntrls
{
    public class CreateSingleKeyCodeCntrl : MonoBehaviour
    {
        public Text KeyCodeText;
        private Temp _temp;
        private SceneNavigator _sceneNavigator;
        [Inject]
        public void Construct(Temp temp, SceneNavigator sceneNavigator)
        {
            _temp = temp;
            _sceneNavigator = sceneNavigator;
        }
        private void Update()
        {
            if ((!Input.anyKeyDown || string.IsNullOrWhiteSpace(Input.inputString)) && !Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }

            var res = Input.GetKeyDown(KeyCode.Space) ? "Space" : Input.inputString;
            KeyCodeText.text = res;
        }

        public void OnClickNextBtn()
        {
            if (string.IsNullOrWhiteSpace(KeyCodeText.text))
            {
                return;
            }
            _temp.GroupItem.SetKeyCodeSingleMode(KeyCodeText.text);
            _sceneNavigator.GoToNextScene("CreateFigureItemScene");
        }
    }
}
