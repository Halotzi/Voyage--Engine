using System.Windows.Forms;
using Voyage_Engine.Assest.Sprites;
using Voyage_Engine.Console;
using Voyage_Engine.Game_Engine.GameObjectSystem;

namespace Voyage_Engine.Game_Engine.Objects
{
    public class Warrior : GameObject
    {
        public override void Start()
        {
            Debug.Log(Application.StartupPath);
            AddComponent<WarriorSprite>();
            base.Start();
        }
    }
}