using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.Objects;
using Voyage_Engine.Game_Engine.SceneSystem;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Assest.Scenes
{
    public class MainScene : Scene
    {
        public override int BuildIndex => 0;

        public override void StartScene()
        {
            var gameObject = Factory.Instantiate<Warrior>(new Vector2(50,50),new Vector2(100,100));
            
            base.StartScene();
        }
    }
}