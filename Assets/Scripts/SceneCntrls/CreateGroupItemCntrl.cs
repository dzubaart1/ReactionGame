using Models;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SceneCntrls
{
    public class CreateGroupItemCntrl : MonoBehaviour
    {
        public InputField NameInputField, CountInputField, InstructionInputField;
        public Toggle IsOneKeyCode;
        private Temp _settings;
        private SceneNavigator _sceneNavigator;
        [Inject]
        public void Construct(Temp settings, SceneNavigator sceneNavigator)
        {
            _settings = settings;
            _sceneNavigator = sceneNavigator;
        }

        public void OnClickNextBtn()
        {
            var name = NameInputField.text;
            var countStr = CountInputField.text;
            var instruction = InstructionInputField.text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(instruction) ||
                !int.TryParse(countStr, out var count))
            {
                return;
            }

            _settings.GroupItem = new GroupItem(name, instruction, count);
            _sceneNavigator.GoToNextScene(IsOneKeyCode.isOn ? "CreateSingleKeyCodeScene" : "CreateFigureItemScene");
        }
    }
}
