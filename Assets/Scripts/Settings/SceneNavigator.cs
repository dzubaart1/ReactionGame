using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Settings
{
    public class SceneNavigator
    {
        private string _currentScene;
        private Stack<string> _previousScenes;

        public SceneNavigator(string curScene)
        {
            _currentScene = curScene;
            _previousScenes = new Stack<string>();
        }

        public void GoToNextScene(string nextScene)
        {
            _previousScenes.Push(_currentScene);
            _currentScene = nextScene;
            SceneManager.LoadScene(_currentScene);
        }
    
        public void GoToBackScene()
        {
            _currentScene = _previousScenes.Pop();
            SceneManager.LoadScene(_currentScene);
        }
    }
}
