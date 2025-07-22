using HarmonyLib;
using Pigeon.UI;
using System;
using System.Runtime.InteropServices;

namespace MycoNoBackgroundHover.Patches;

[HarmonyPatch(typeof(AlphaGroupButton))]
public class AlphaGroupButtonPatch
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