using System;
using System.Runtime.InteropServices;
using HarmonyLib;
using Pigeon.UI;

namespace NoBackgroundHover.Patches;

[HarmonyPatch(typeof(ColorButton))]
public class ColorButtonPatch
{
    [HarmonyPrefix]
    [HarmonyPatch("OnPointerEnter")]
    static bool Prefix_OnPointerEnter() => Plugin.IsGameFocused();
    [HarmonyPrefix]
    [HarmonyPatch("OnPointerExit")]
    static bool Prefix_OnPointerExit() => Plugin.IsGameFocused();
    [HarmonyPrefix]
    [HarmonyPatch("OnPointerUp")]
    static bool Prefix_OnPointerUp() => Plugin.IsGameFocused();
    [HarmonyPrefix]
    [HarmonyPatch("OnPointerDown")]
    static bool Prefix_OnPointerDown() => Plugin.IsGameFocused();
}