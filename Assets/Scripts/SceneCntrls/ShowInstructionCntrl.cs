using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SceneCntrls
{
    public class ShowInstructionCntrl : MonoBehaviour
    {
        public Text InstructionText;
        private SceneNavigator _sceneNavigator;
        private Temp _temp;
    
        [Inject]
        public void Constrct(SceneNavigator sceneNavigator, Temp temp)
        {
            _temp = temp;
            _sceneNavigator = sceneNavigator;
        }

        private void Start()
        {
            InstructionText.text = _temp.GroupItem.Instruction;
        }

        public void OnClickBackBtn()
        {
            _sceneNavigator.GoToBackScene();
        }

        public void OnClickStartBtn()
        {
            _sceneNavigator.GoToNextScene("LevelScene");
        }
    }
}
