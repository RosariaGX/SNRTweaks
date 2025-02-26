using HarmonyLib;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    public class WelderSpeedPatch
    {
        private static float defaultWeldSpeed;

        [HarmonyPatch(typeof(Welder), nameof(Welder.OnToolUseAnim)), HarmonyPostfix]
        private static void WelderOnToolUseAnim_Postfix(Welder __instance) 
        { 
            if (Plugin.Options.wasWelderSliderChanged)
            {
                defaultWeldSpeed = __instance.healthPerWeld;

                __instance.healthPerWeld = defaultWeldSpeed * Plugin.Options.welderSpeedMultiplier;
            }
        }
    }
}
