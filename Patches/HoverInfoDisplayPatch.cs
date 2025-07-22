using HarmonyLib;
using Pigeon;

namespace MycoNoBackgroundHover.Patches;

[HarmonyPatch(typeof(HoverInfoDisplay))]
public class HoverInfoDisplayPatch
{
    [HarmonyPrefix]
    [HarmonyPatch("OnHoverEnter")]
    static bool OnHoverEnter_Prefix() => Plugin.IsGameFocused();
    [HarmonyPrefix]
    [HarmonyPatch("Activate")]
    static bool Activate_Prefix() => Plugin.IsGameFocused();
}