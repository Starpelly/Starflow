using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;

namespace Starflow
{
    public class GameRuntime : GameManager
    {
        public string ApplicationTitle;
        public Scene StartingScene;

        public static new GraphicsDevice GraphicsDevice => Instance.GraphicsDevice;

        public GameRuntime()
        {
        }

        public override void Start()
        {
            for (int i = 0; i < StartingScene.gameObjects.Count; i++)
            {
                GameObject gameObject = StartingScene.gameObjects[i];
                Assembly assembly = Assembly.LoadFrom(@"C:\Dev\Starflow\Starflow.Editor\bin\Debug\net6.0-windows\Sandbox.dll");
                foreach (Type type in assembly.GetTypes())
                {
                    var baseType = type.BaseType.FullName;
                    Component t = (Component)Activator.CreateInstance(type);
                    t.gameObject = gameObject;
                    gameObject.components.Add(t);
                    GameManager.Components.Add((MonoBehaviour)(object)t);
                    // gameObject.AddComponent(c);
                }
            }
            Window.Title = ApplicationTitle;
            ChangeScene(StartingScene);
        }
    }
}
