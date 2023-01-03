using System.Collections.Generic;
using System.Runtime.InteropServices;
using Voyage_Engine.Game_Engine.ComponentSystem;
using Voyage_Engine.Game_Engine.FactorySystem;
using Voyage_Engine.Game_Engine.TransformSystem;

namespace Voyage_Engine.Game_Engine.GameObjectSystem
{
    public class GameObject : BaseObject , IInstantiate , IGameObject
    {
        private string _name;
        private Transform _transform;
        private bool _isActive;
        
        private List<IComponent> _components;
        
        public List<IComponent> Components => _components;
        public string Name => _name;
        public Transform Transform => _transform;
        public bool IsActive => _isActive;
        
        public GameObject GameObjectConstructor(Transform transform,string name)
        {
            InitializedBaseObject();

            _components = new List<IComponent>();
            
            transform.SetGameObject(this);

            _name = name;

            _transform = transform;

            return this;
        }

        public void AddComponent<T>() where T : IComponent , new()
        {
            T component = new T();
            
            _components.Add(component);
        }
        
        public void SetActive(bool isActive)
        {
            //need active logic
            _isActive = isActive;
        }
        
        public override string ToString()
        {
            return GetType().Name;
        }

        public virtual void Start()
        {
            foreach (var component in _components)
                component.InitComponent(this);
        }

        public virtual void Update()
        {
            foreach (var component in _components)
                component.UpdateComponent();
        }

        public virtual void LateUpdate()
        {
            
        }
    }
}