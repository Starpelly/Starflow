using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using MonoGame.ImGui;
using Tickflow;
using ImGuiNET;

namespace GameExample
{
    public class MainGame : GameManager
    {
        public ImGUIRenderer renderer;

        public override void Start()
        {
            ChangeScene(new TestScene());
        }

        public override void Init()
        {
            renderer = new ImGUIRenderer(this).Initialize().RebuildFontAtlas();
            ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;
        }

        public override void Draw(SpriteBatch sb, GameTime gameTime)
        {
            renderer.BeginLayout(gameTime);
            renderer.EndLayout();
        }
    }
}
