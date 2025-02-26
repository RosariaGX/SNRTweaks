using HarmonyLib;

namespace SNRTweaks.Patches.Utility
{
    [HarmonyPatch]
    public class LaserSpeedPatch
    {
        private static float defaultWeldSpeed;

        [HarmonyPatch(typeof(LaserCutter), nameof(LaserCutter.OnToolUseAnim)), HarmonyPostfix]
        private static void WelderOnToolUseAnim_Postfix(LaserCutter __instance) 
        { 
            if (Plugin.Options.wasWelderSliderChanged)
            {
                defaultWeldSpeed = __instance.healthPerWeld;

                __instance.healthPerWeld = defaultWeldSpeed * Plugin.Options.welderSpeedMultiplier;
            }
        }
    }
}
