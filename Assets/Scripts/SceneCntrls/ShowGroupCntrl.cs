using Cntrls;
using Collections;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SceneCntrls
{
    public class ShowGroupCntrl : MonoBehaviour
    {
        public Text NameGroupText, CountFigureItemsInGroupText, InstructionText, KeyCodeSingleMode, IsSingleModeText;
        public FigureItemListCntrl FigureItemListCntrl;
        private Temp _temp;
        private GroupItemCollection _groupItemCollection;
        private SceneNavigator _sceneNavigator;
        [Inject]
        public void Construct(Temp temp, GroupItemCollection groupItemCollection, SceneNavigator sceneNavigator)
        {
            _temp = temp;
            _groupItemCollection = groupItemCollection;
            _sceneNavigator = sceneNavigator;
        }

        private void Start()
        {
            FigureItemListCntrl.InitializeFigureItems(_temp.GroupItem);
            KeyCodeSingleMode.text = _temp.GroupItem.KeyCodeSingleMode;
            IsSingleModeText.text = _temp.GroupItem.IsSingleMode.ToString();
            NameGroupText.text = _temp.GroupItem.Name;
            InstructionText.text = _temp.GroupItem.Instruction;
            CountFigureItemsInGroupText.text = _temp.GroupItem.Count.ToString();
        }
        
        public void OnClickGroupsEditor()
        {
            _sceneNavigator.GoToNextScene("GroupsEditor");
        }

        public void OnClickRoundsEditor()
        {
            _sceneNavigator.GoToNextScene("RoundsEditorScene");
        }

        public void OnClickDeleteBtn()
        {
            _groupItemCollection.DeleteGroupItem(_temp.GroupItem);
            _sceneNavigator.GoToNextScene("GroupsEditor");
        }
    }
}