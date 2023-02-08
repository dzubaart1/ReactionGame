using System;
using Models;
using Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SceneCntrls
{
    public class ResultsCntrl : MonoBehaviour
    {
        public Text RightAnswersText,
            WrongAnswersText,
            AverageRightAnswersText,
            AverageWrongAnswersText,
            GameTimeText,
            SkipsAnswersText,
            AverageAnswersText;
        private Temp _temp;
        private int rightAnswers, wrongAnswers, skipAnswers;
        private double rightAnswersSumTime, wrongAnswersSumTime;
        private SceneNavigator _sceneNavigator;
        [Inject]
        public void Construct(Temp temp, SceneNavigator sceneNavigator)
        {
            _temp = temp;
            _sceneNavigator = sceneNavigator;
        }

        private void Start()
        {
            if (_temp.GroupItem.IsSingleMode)
            {
                CountRightWrongAnswersInSignle();
            
            }
            else
            {
                CountRightWrongAnswersInMulti();
            }

            RightAnswersText.text = rightAnswers.ToString();
            WrongAnswersText.text = wrongAnswers.ToString();
            SkipsAnswersText.text = skipAnswers.ToString();
        
            if (rightAnswers > 0)
            {
                AverageRightAnswersText.text =
                    Math.Round(rightAnswersSumTime / rightAnswers,3).ToString();
            }
            if (wrongAnswers > 0)
            {
                AverageWrongAnswersText.text =
                    Math.Round(wrongAnswersSumTime / wrongAnswers,3).ToString();
            }
            AverageAnswersText.text = 
                Math.Round((wrongAnswersSumTime+rightAnswersSumTime) / (wrongAnswers+rightAnswers),3).ToString();
        
            GameTimeText.text = Math.Round(_temp.Result.GameTime, 3).ToString();
        }

        private void CountRightWrongAnswersInMulti()
        {
            var roundCntrl = _temp.GroupItem.RoundCntrlList[_temp.Result.RoundIndex];
            for(int i = 0; i < _temp.Result.AnswersList.Count; i++)
            {
                if (_temp.Result.AnswersList[i].GetKeyCode().Equals("Skip"))
                {
                    skipAnswers++;
                }
                else if (_temp.Result.AnswersList[i].GetKeyCode() == roundCntrl.GetFigireItemById(i).KeyCode)
                {
                    rightAnswers++;
                    rightAnswersSumTime += _temp.Result.AnswersList[i].GetTime();
                }
                else
                {
                    wrongAnswers++;
                    wrongAnswersSumTime += _temp.Result.AnswersList[i].GetTime();
                }
            }
        }
        private void CountRightWrongAnswersInSignle()
        {
            var roundCntrl = _temp.GroupItem.RoundCntrlList[_temp.Result.RoundIndex];
            for(int i = 0; i < _temp.Result.AnswersList.Count; i++)
            {
                if (_temp.Result.AnswersList[i].GetKeyCode().Equals("Skip") && roundCntrl.GetFigireItemById(i).SpriteName.Equals(_temp.FigureItem.SpriteName))
                {
                    skipAnswers++;
                }
                else if (_temp.Result.AnswersList[i].GetKeyCode() == _temp.GroupItem.KeyCodeSingleMode && roundCntrl.GetFigireItemById(i).SpriteName.Equals(_temp.FigureItem.SpriteName))
                {
                    rightAnswers++;
                    rightAnswersSumTime += _temp.Result.AnswersList[i].GetTime();
                }
                else if(_temp.Result.AnswersList[i].GetKeyCode() == _temp.GroupItem.KeyCodeSingleMode && !roundCntrl.GetFigireItemById(i).SpriteName.Equals(_temp.FigureItem.SpriteName))
                {
                    wrongAnswers++;
                    wrongAnswersSumTime += _temp.Result.AnswersList[i].GetTime();
                }
            }
        }

        public void OnClickMainMenuBtn()
        {
            _sceneNavigator.GoToNextScene("MainMenu");
        }
    }
}
