using System;
using System.Runtime.InteropServices;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace MycoNoBackgroundHover
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern IntPtr GetActiveWindow();

        public static bool IsGameFocused() => GetForegroundWindow() == GetActiveWindow();

        internal static new ManualLogSource Logger;
        private Harmony _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

        private void Awake()
        {
            Logger = base.Logger;

            _harmony.PatchAll(typeof(Patches.DefaultButtonPatch));
            _harmony.PatchAll(typeof(Patches.DurationButtonPatch));
            _harmony.PatchAll(typeof(Patches.SpriteButtonPatch));
            _harmony.PatchAll(typeof(Patches.ColorButtonPatch));
            _harmony.PatchAll(typeof(Patches.ColorButtonInstantPatch));
            _harmony.PatchAll(typeof(Patches.AlphaGroupButtonPatch));
            _harmony.PatchAll(typeof(Patches.OutlineThicknessButtonPatch));
            _harmony.PatchAll(typeof(Patches.PositionButtonPatch));
            _harmony.PatchAll(typeof(Patches.RectSizeButtonPatch));
            _harmony.PatchAll(typeof(Patches.RectSizeButtonActivePatch));
            _harmony.PatchAll(typeof(Patches.HoverInfoDisplayPatch));

            Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}