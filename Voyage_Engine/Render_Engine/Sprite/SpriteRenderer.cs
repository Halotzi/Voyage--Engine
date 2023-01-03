using System;
using System.Drawing;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.ResourcesSystem;
using Voyage_Engine.Rendere_Engine.RenderedObjects;

namespace Voyage_Engine.Rendere_Engine.Sprite
{
    public abstract class SpriteRenderer : RenderObject
    {
        private Image _sprite;
        private bool _isInitialized;
        protected abstract string Path { get; } 
        
        protected SpriteRenderer()
        {
            try
            {
                _sprite = Resources.LoadImage(Path);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        public override void Render(Graphics graphics)
        {
            if(!_isInitialized)
                return;

            //PointF point = new PointF(Transform.Position.X,Transform.Position.Y);
            //SizeF size = new SizeF(Transform.Scale.X, Transform.Scale.Y);
            
            graphics.DrawImage(_sprite,(int)Transform.Position.X,(int)Transform.Position.Y,(int)Transform.Scale.X,(int)Transform.Scale.Y);
        }

        public override void InitComponent(GameObject gameObject)
        {
            base.InitComponent(gameObject);
            _isInitialized = true;
        }
    }
}