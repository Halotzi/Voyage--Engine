using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Voyage_Engine.Assest.Scenes;
using Voyage_Engine.Game_Engine.InputSystem;
using Voyage_Engine.Game_Engine.ResourcesSystem;
using Voyage_Engine.Game_Engine.SceneSystem;
using Voyage_Engine.Game_Engine.TransformSystem;
using Voyage_Engine.Rendere_Engine;
using Voyage_Engine.Rendere_Engine.Vector;

namespace Voyage_Engine.Game_Engine.Engine
{
    public class MainGameEngine
    {
        public event Action OnEndUpdate;

        public static string MainPath => Application.StartupPath;

        private MainRenderEngine _mainRenderEngine;
        
        private static List<Scene> _scenes;

        private static Scene _currentScene;

        public static Scene CurrentScene => _currentScene;

        public static Transform RootTransform => CurrentScene.RootTransform;

        public MainGameEngine()
        {
            _mainRenderEngine = new MainRenderEngine(new Vector2(1000, 1000), "Voyage Engine");
            InputReceiver.Init(_mainRenderEngine.Window);
            Resources.Init();

            _scenes = new List<Scene>();
            
            _mainRenderEngine.OnBeforeFrame += Update;
            _mainRenderEngine.OnBeforeFirstFrame += Start;
            _mainRenderEngine.OnAfterFrame += LateUpdate;
            _mainRenderEngine.OnCloseWindow += ExitEngine;
           
            
            _mainRenderEngine.OpenWindow();
        }
        
        public static void RegisterScene(Scene scene)
        {
            _scenes.Add(scene);
        }

        private static void Start()
        {
            var scene = _scenes.OrderBy(x => x.BuildIndex);

            _currentScene = new MainScene();
            
            _currentScene.StartScene();
        }

        private static void Update()
        {
           _currentScene.UpdateScene();
        }

        private static void LateUpdate()
        {
            
        }

        private void ExitEngine()
        {
            _mainRenderEngine.OnBeforeFrame -= Update;
            _mainRenderEngine.OnBeforeFirstFrame -= Start;
            _mainRenderEngine.OnCloseWindow -= ExitEngine;
            _mainRenderEngine.OnAfterFrame -= LateUpdate;
            
            InputReceiver.Dispose();
        }
    }
}