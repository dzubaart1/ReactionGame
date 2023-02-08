using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Cntrls
{
    public class LevelItemPrefabCntrl : MonoBehaviour
    {
        public Text NameText, TimeStartText, TimePauseText;
        private LevelItem _levelItem;

        public void InitializeLeveItem(LevelItem levelItem)
        {
            NameText.text = levelItem.Name;
            TimeStartText.text = levelItem.TimeStart.ToString();
            TimePauseText.text = levelItem.TimePause.ToString();
        }
    }
}
