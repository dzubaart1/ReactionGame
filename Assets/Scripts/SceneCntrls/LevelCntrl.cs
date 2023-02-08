using System.Collections;
using System.Collections.Generic;
using Collections;
using Models;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace SceneCntrls
{
    public class LevelCntrl : MonoBehaviour
    {
        public AudioSource AudioSource;
        public Image FigureItem;
        public Text InfoText;
        public Sprite RelaxImg, ListenImg;
        private Temp _temp;
        private SpritesCollection _spritesCollection;
        private SoundCollection _soundCollection;
        private SceneNavigator _sceneNavigator;
        private double gameTime,startTime;
        private List<Answer> _answersList;
        [Inject]
        public void Construct(Temp temp, SpritesCollection spritesCollection, SceneNavigator sceneNavigator, SoundCollection soundCollection)
        {
            _temp = temp;
            _spritesCollection = spritesCollection;
            _soundCollection = soundCollection;
            _sceneNavigator = sceneNavigator;
        }

        private void Update()
        {
            gameTime += Time.deltaTime;
        }

        public void Start()
        {
            _answersList = new List<Answer>();
            var randomIndex = Random.Range(0, _temp.GroupItem.RoundCntrlList.Count - 1);
            var timeStart = _temp.LevelItem.TimeStart;
            var timePause = _temp.LevelItem.TimePause;
        
            StartCoroutine(StartGame(randomIndex, timeStart, timePause));
        }
    
        private IEnumerator StartGame(int randomFigureItemsIndex, float timeStart, float timePause)
        {
            yield return StartCoroutine(СountDown(3));
            foreach (var figureItem in _temp.GroupItem.RoundCntrlList[randomFigureItemsIndex].FigureItems)
            {
                var sprite = _spritesCollection.FindSpriteByName(figureItem.SpriteName);
                if (!figureItem.SoundName.Equals("None"))
                {
                    InfoText.text = "Слушайте!";
                    FigureItem.sprite = ListenImg;
                    AudioSource.clip = _soundCollection.FindSoundByName(figureItem.SoundName);
                    AudioSource.Play();
                    yield return new WaitWhile(() => AudioSource.isPlaying);
                }
                yield return StartCoroutine(StartRound(sprite, timeStart));
                yield return StartCoroutine(RelaxTime(timePause));
            }

            var result = new Result(_answersList, randomFigureItemsIndex, gameTime);
            _temp.Result = result;
            _sceneNavigator.GoToNextScene("ResultsScene");
        }
        private IEnumerator СountDown(float secondsCount)
        {
            InfoText.text = "Приготовьтесь!";
            FigureItem.sprite = RelaxImg;
            yield return new WaitForSeconds(secondsCount);
        }
    
        private IEnumerator RelaxTime(float secondsCount)
        {
            InfoText.text = "Отдыхайте!";
            FigureItem.sprite = RelaxImg;
            yield return new WaitForSeconds(secondsCount);
        }
    
        private IEnumerator StartRound(Sprite sprite,float timeStart)
        {
            InfoText.text = "Играйте!";
            FigureItem.sprite = sprite;
            startTime = gameTime;
            yield return new WaitUntil(() => Input.anyKeyDown || gameTime >= startTime + timeStart);
            _answersList.Add(new Answer(Input.inputString, gameTime - startTime));
        }
    }
}
