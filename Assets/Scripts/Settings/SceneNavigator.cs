using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Settings
{
    public class SceneNavigator
    {
        private string _currentScene;
        private Stack<string> _previousScenes;

        public SceneNavigator(string prevScene, string curScene)
        {
            _currentScene = curScene;
            _previousScenes = new Stack<string>();
            _previousScenes.Push(prevScene);
        }

        public void GoToNextScene(string nextScene)
        {
            _previousScenes.Push(_currentScene);
            _currentScene = nextScene;
            SceneManager.LoadScene(nextScene);
        }
    
        public void GoToBackScene()
        {
            _currentScene = _previousScenes.Pop();
            SceneManager.LoadScene(_currentScene);
        }
    }
}
