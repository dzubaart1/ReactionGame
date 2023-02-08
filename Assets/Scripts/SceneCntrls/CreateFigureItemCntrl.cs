using Collections;
using Models;
using Settings;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace SceneCntrls
{
    public class CreateFigureItemCntrl : MonoBehaviour
    {
        public TMP_Dropdown SpritesDropdown,SoundsDropdown;
        public Text TitleText, KeyText;
        private SpritesCollection _spritesCollection;
        private Temp _settings;
        private GroupItemCollection _groupItemCollection;
        private SceneNavigator _sceneNavigator;
        private SoundCollection _soundCollection;
    
        [Inject]
        public void Construct(SpritesCollection spritesCollection, Temp settings, GroupItemCollection groupItemCollection, SceneNavigator sceneNavigator, SoundCollection soundCollection)
        {
            _spritesCollection = spritesCollection;
            _settings = settings;
            _groupItemCollection = groupItemCollection;
            _sceneNavigator = sceneNavigator;
            _soundCollection = soundCollection;
        }
        private void Start()
        {
            TitleText.text = $"Введите {_settings.GroupItem.GetNextPos()} элемент группы";
            InitializeSpritesDropDown(SpritesDropdown);
            InitializeSoundsDropDown(SoundsDropdown);
        }

        private void Update()
        {
            if ((!Input.anyKeyDown || string.IsNullOrWhiteSpace(Input.inputString)) && !Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }

            var res = Input.GetKeyDown(KeyCode.Space) ? "Space" : Input.inputString;
            KeyText.text = res;
        }

        public void OnClickNextBtn()
        {
            if (string.IsNullOrWhiteSpace(SpritesDropdown.captionText.text) || string.IsNullOrWhiteSpace(KeyText.text))
            {
                return;
            }
        
            _settings.GroupItem.AddFigureItem(new FigureItem(KeyText.text, SpritesDropdown.captionText.text, SoundsDropdown.captionText.text));
            if (_settings.GroupItem.IsEnoughItems())
            {
                _groupItemCollection.AddGroupItem(_settings.GroupItem);
                _sceneNavigator.GoToNextScene("ShowGroupScene");
            }
            else
            {
                _sceneNavigator.GoToNextScene(SceneManager.GetActiveScene().name);
            }
        }

        private void InitializeSpritesDropDown(TMP_Dropdown dropdown)
        {
            foreach (var sprite in _spritesCollection.Sprites)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData(sprite.name, sprite));
            }
        }
    
        private void InitializeSoundsDropDown(TMP_Dropdown dropdown)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData("None"));
            foreach (var sound in _soundCollection.Sounds)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData(sound.name));
            }
        }
    }
}
