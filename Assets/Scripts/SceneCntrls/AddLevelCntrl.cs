using Models;
using Settings;
using TMPro;
using UnityEngine;
using Zenject;

namespace SceneCntrls
{
    public class AddLevelCntrl : MonoBehaviour
    {
        public TMP_InputField NameInputField, TimeStartInputField, TimePauseInputField;
        private LevelItemCollection _levelItemCollection;
        private SceneNavigator _sceneNavigator;
        [Inject]
        public void Construct(LevelItemCollection levelItemCollection, SceneNavigator sceneNavigator)
        {
            _levelItemCollection = levelItemCollection;
            _sceneNavigator = sceneNavigator;
        }

        public void OnClickDoneBtn()
        {
            if (string.IsNullOrWhiteSpace(NameInputField.text)
                || !float.TryParse(TimeStartInputField.text, out float timeStart)
                || !float.TryParse(TimePauseInputField.text, out float timePause))
            {
                return;
            }
            var levelItem = new LevelItem(NameInputField.text, timeStart, timePause);

            _levelItemCollection.AddLevelItem(levelItem);
        
            _sceneNavigator.GoToNextScene("LevelsEditorScene");
        }
    }
}
