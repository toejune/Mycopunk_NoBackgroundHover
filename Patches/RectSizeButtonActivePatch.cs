using HarmonyLib;
using System;
using System.Runtime.InteropServices;
using Pigeon.UI;

namespace NoBackgroundHover.Patches;

[HarmonyPatch(typeof(RectSizeButtonActive))]
public class RectSizeButtonActivePatch
{
    [HarmonyPrefix]
    [HarmonyPatch("SetHover")]
    static bool Prefix_SetHover() => Plugin.IsGameFocused();
}