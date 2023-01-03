using System.Runtime.CompilerServices;
using System.Security;
using System;
using Voyage_Engine.Console;
using Voyage_Engine.Game_Engine.GameObjectSystem;
using Voyage_Engine.Game_Engine.TransformSystem;
using Voyage_Engine.Game_Engine.SceneSystem;

namespace Voyage_Engine.Game_Engine.ComponentSystem
{
    public class Component : BaseObject, IComponent
    {
        private Transform _transform;
        private GameObject _gameObject;

        public Transform Transform => _transform;

        public GameObject GameObject => _gameObject;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public virtual void InitComponent(GameObject gameObject)
        {
            InitializedBaseObject();

            _gameObject = gameObject;
            _transform = gameObject.Transform;
        }

        public virtual T GetComponent<T>(T typeToSearch) where T : IComponent
        {
            for (int i = 0; i < _gameObject.Components.Count; i++)
            {
                if (_gameObject.Components[i].Equals(typeToSearch))
                    return (T)_gameObject.Components[i];
            }
            return default(T);
        }
    }
}