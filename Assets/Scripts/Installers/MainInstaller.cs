using Collections;
using Data;
using Models;
using Settings;
using Zenject;

namespace Installers
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneNavigator();
            BindCollections();
            BindSettings();
        }

        private void BindSceneNavigator()
        {
            SceneNavigator sceneNavigator = new SceneNavigator("MainMenu");
            Container.Bind<SceneNavigator>().FromInstance(sceneNavigator).AsSingle();
        }
        
        private void BindSettings()
        {
            Temp temp = new Temp();
            Container.Bind<Temp>().FromInstance(temp).AsSingle();
        }

        private void BindCollections()
        {
            SoundCollection soundCollection = new SoundCollection();
            Container.Bind<SoundCollection>().FromInstance(soundCollection).AsSingle();
            
            LevelItemCollection levelItemCollection = JsonStorage.LoadLevelItemCollection() ?? new LevelItemCollection();
            Container.Bind<LevelItemCollection>().FromInstance(levelItemCollection).AsSingle();
            
            SpritesCollection spritesCollection = new SpritesCollection();
            Container.Bind<SpritesCollection>().FromInstance(spritesCollection).AsSingle();
            
            GroupItemCollection groupItemCollection = JsonStorage.LoadGroupItemCollection() ?? new GroupItemCollection();
            Container.Bind<GroupItemCollection>().FromInstance(groupItemCollection).AsSingle();
        }
    }
}
