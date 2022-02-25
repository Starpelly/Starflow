using System;
using System.Linq;
using ImGuiNET;

namespace Starflow.Editor
{
    [CustomEditor(typeof(AudioSource))]
    public class AudioSourceEditor : Editor
    {
        public override void Imgui(Component component)
        {
            AudioSource audioSource = (AudioSource)component;
            ImGui.Checkbox("Mute", ref audioSource.mute);
            ImGui.Checkbox("Play On Awake", ref audioSource.mute);
            ImGui.Checkbox("Loop", ref audioSource.loop);

            ImGui.DragFloat("Volume", ref audioSource.volume);
            ImGui.DragFloat("Pitch", ref audioSource.pitch);
        }
    }
}