using HarmonyLib;
using System;
using System.Runtime.InteropServices;
using Pigeon.UI;

namespace MycoNoBackgroundHover.Patches;

[HarmonyPatch(typeof(RectSizeButtonActive))]
public class RectSizeButtonActivePatch
{
    [HarmonyPrefix]
    [HarmonyPatch("SetHover")]
    static bool Prefix_SetHover() => Plugin.IsGameFocused();
}